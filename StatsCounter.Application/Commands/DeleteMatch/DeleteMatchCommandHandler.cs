using MediatR;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Commands.DeleteMatch
{
    public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, Unit>
    {
        private readonly IMatchRepository _matchRepository;
        public DeleteMatchCommandHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        public async Task<Unit> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            await _matchRepository.DeleteMatchAsync(request.id);
            return Unit.Value;
        }
    }
}
