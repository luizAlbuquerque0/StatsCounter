using MediatR;
using StatsCounter.Application.ViewModels;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Queries.GetAllPlayerMatches
{
    public class GetAllPlayerMatchesQueryHandler : IRequestHandler<GetAllPlayerMatchesQuery, List<MatchDetailsViewModel>>
    {
        private readonly IMatchRepository _matchRepository;
        public GetAllPlayerMatchesQueryHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<List<MatchDetailsViewModel>> Handle(GetAllPlayerMatchesQuery request, CancellationToken cancellationToken)
        {
            var matches = await _matchRepository.GetAllMatchesByPlayerIdAsync(request.PlayerId);

            return matches.Select(m => new MatchDetailsViewModel(m.Id, m.TouchDowns, m.Interceptations, m.CompletedPasses, m.AttemptedPasses, m.PassedYards, m.Date, m.Player)).ToList();
        }
    }
}
