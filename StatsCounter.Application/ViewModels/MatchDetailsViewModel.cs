using StatsCounter.Core.Entities;

namespace StatsCounter.Application.ViewModels
{
    public class MatchDetailsViewModel
    {
        public MatchDetailsViewModel(int id, int touchDowns, int interceptations, int completedPasses, int attemptedPasses, int passedYards, DateTime date, Player player)
        {
            Id = id;
            TouchDowns = touchDowns;
            Interceptations = interceptations;
            CompletedPasses = completedPasses;
            AttemptedPasses = attemptedPasses;
            PassedYards = passedYards;
            Date = date;
            Player = player;
        }

        public int Id { get; private set; }
        public int TouchDowns { get; private set; }
        public int Interceptations { get; private set; }
        public int CompletedPasses { get; private set; }
        public int AttemptedPasses { get; private set; }
        public int PassedYards { get; private set; }
        public DateTime Date { get; private set; }
        public Player Player { get; private set; }

    }
}
