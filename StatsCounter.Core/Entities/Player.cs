namespace StatsCounter.Core.Entities
{
    public class Player : BaseEntity
    {
        public Player(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Matches = new List<Match>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Match> Matches { get; private set; }

        public void matches(List<Match> matches)
        {
            Matches = matches;
        }

        public int GetTotalTouchdowns()
        {
            return Matches.Select(m=>m.TouchDowns).Sum();
        }

        public int GetTotalInterceptations()
        {
            return (Matches.Select(m=>m.Interceptations).Sum());
        }

        public int GetTotalCompletedPasses()
        {
            return Matches.Select(m => m.Interceptations).Sum();
        }

        public int GetNumberOfAttemptedPasses()
        {
            return Matches.Select(m => m.AttemptedPasses).Sum();
        }

        public int GetTotalPassedYards()
        {
            return Matches.Select(m =>m.PassedYards).Sum(); 
        }
    }
}
