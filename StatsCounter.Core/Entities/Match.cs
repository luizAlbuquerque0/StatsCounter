namespace StatsCounter.Core.Entities
{
    public class Match : BaseEntity
    {
        public Match(int playerId, DateTime date)
        {
            PlayerId = playerId;
            Date = date;
        }

        public int TouchDowns { get; private set; }
        public int Interceptations { get; private set; }
        public int CompletedPasses { get; private set; }
        public int AttemptedPasses { get; private set; }
        public int PassedYards { get; private set; }
        public int PlayerId { get; private set; }
        public DateTime Date { get; private set; }
    }
}
