using Microsoft.EntityFrameworkCore;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Infrastructure.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly StatsCounterDbContext _dbContext;
        public PlayerRepository(StatsCounterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatePlayerAsync(Player player)
        {
            await _dbContext.Players.AddAsync(player);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<Player> GetPlayerByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext.Players.SingleOrDefaultAsync(p => p.Email == email && p.Password == password);
        }

        public async Task<Player> GetUserByIdAsync(int id)
        {
            return await _dbContext.Players.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
