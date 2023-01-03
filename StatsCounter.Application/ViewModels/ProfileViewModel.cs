namespace StatsCounter.Application.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel(int playedMatchs, int totalTouchDowns, int totalInterceptations, int totalCompletedPasses, int totalAttemptedPasses, int totalPassedYards, List<SimplifyedMatchViewModel    > matchs)
        {
            PlayedMatchs = playedMatchs;
            TotalTouchDowns = totalTouchDowns;
            TotalInterceptations = totalInterceptations;
            TotalCompletedPasses = totalCompletedPasses;
            TotalAttemptedPasses = totalAttemptedPasses;
            TotalPassedYards = totalPassedYards;
            Matchs = matchs;
        }

        public int PlayedMatchs { get; private set; }
        public int TotalTouchDowns { get; private set; }
        public int TotalInterceptations { get; private set; }
        public int TotalCompletedPasses { get; private set; }
        public int TotalAttemptedPasses { get; private set; }
        public int TotalPassedYards { get; private set; }
        public List<SimplifyedMatchViewModel> Matchs { get; set; }
    }
}
