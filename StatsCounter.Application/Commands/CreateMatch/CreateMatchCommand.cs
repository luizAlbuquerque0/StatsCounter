using MediatR;

namespace StatsCounter.Application.Commands.CreateMatch
{
    public class CreateMatchCommand : IRequest<int?>
    {
        public CreateMatchCommand(int playerId, DateTime date)
        {
            PlayerId = playerId;
            Date = date;
        }

        public int PlayerId { get; private set; }
        public DateTime Date { get; private set; }
    }
}
