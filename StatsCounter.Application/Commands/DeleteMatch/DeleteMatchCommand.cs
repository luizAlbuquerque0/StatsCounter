using MediatR;

namespace StatsCounter.Application.Commands.DeleteMatch
{
    public class DeleteMatchCommand : IRequest<Unit>
    {
        public DeleteMatchCommand(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }
    }
}
