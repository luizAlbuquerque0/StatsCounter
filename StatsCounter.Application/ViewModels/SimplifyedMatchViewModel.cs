namespace StatsCounter.Application.ViewModels
{
    public class SimplifyedMatchViewModel
    {
        public SimplifyedMatchViewModel(DateTime date, int passedYards)
        {
            Date = date;
            PassedYards = passedYards;
        }

        public DateTime Date { get; private set; }
        public int PassedYards { get; private set; }
    }
}
