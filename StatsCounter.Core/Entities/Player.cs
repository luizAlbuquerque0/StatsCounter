﻿namespace StatsCounter.Core.Entities
{
    public class Player : BaseEntity
    {
        public Player(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Match> Matches { get; private set; }
    }
}
