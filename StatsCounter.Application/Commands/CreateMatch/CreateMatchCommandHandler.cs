using MediatR;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Commands.CreateMatch
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int?>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRepository;
        public CreateMatchCommandHandler(IMatchRepository matchRepository, IPlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
        }
        public async Task<int?> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetUserByIdAsync(request.PlayerId);
            if (player == null) return null;


            var match = new Match(request.PlayerId, request.Date);
            await _matchRepository.CreateMatchAsync(match);
            await _matchRepository.SaveChangesAsync();
            return match.Id;
        }
    }
}
