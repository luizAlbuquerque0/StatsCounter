using MediatR;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Commands.UpdateMatch
{
    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, Unit>
    {
        private readonly IMatchRepository _matchRepository;
        public UpdateMatchCommandHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        public async Task<Unit> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetMByIdAsync(request.MatchId);

            match.Update(request.TochDowns, request.Interceptations, request.CompletedPasses, request.AttemptedPasses, request.PassedYards);
            await _matchRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
