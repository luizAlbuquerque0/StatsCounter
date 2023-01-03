using MediatR;

namespace StatsCounter.Application.Commands.UpdateMatch
{
    public class UpdateMatchCommand : IRequest<Unit>
    {
        public int MatchId { get; set; }
        public int TochDowns { get;  set; }
        public int Interceptations { get;  set; }
        public int CompletedPasses  { get;  set; }
        public int AttemptedPasses { get;  set; }
        public int PassedYards { get;  set; }

    }
}
