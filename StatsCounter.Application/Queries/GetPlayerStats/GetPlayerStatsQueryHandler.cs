using MediatR;
using StatsCounter.Application.ViewModels;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Queries.GetPlayerStats
{
    public class GetPlayerStatsQueryHandler : IRequestHandler<GetPlayerStatsQuery, ProfileViewModel>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRepository;
        public GetPlayerStatsQueryHandler(IMatchRepository matchRepository, IPlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
        }
        public async Task<ProfileViewModel> Handle(GetPlayerStatsQuery request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetUserByIdAsync(request.PlayerId);

            var matchs = await _matchRepository.GetAllMatchesByPlayerIdAsync(request.PlayerId);
            var matchsViewModel = matchs.Select(m => new SimplifyedMatchViewModel(m.Date, m.PassedYards)).ToList();

            player.matches(matchs);

            return new ProfileViewModel
                (matchs.Count, player.GetTotalTouchdowns(),
                player.GetTotalInterceptations(),
                player.GetTotalCompletedPasses(),
                player.GetNumberOfAttemptedPasses(),
                player.GetTotalPassedYards(),
                matchsViewModel
                );


        }
    }
}
