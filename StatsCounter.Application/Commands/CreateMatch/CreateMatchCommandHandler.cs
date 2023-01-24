using MediatR;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Commands.CreateMatch
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
    {
        private readonly IMatchRepository _matchRepository;
        public CreateMatchCommandHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var match = new Match(request.PlayerId, request.Date);
            await _matchRepository.CreateMatchAsync(match);
            await _matchRepository.SaveChangesAsync();
            return match.Id;
        }
    }
}
