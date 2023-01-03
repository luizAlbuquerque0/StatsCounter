using Microsoft.EntityFrameworkCore;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Infrastructure.Persistence.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly StatsCounterDbContext _dbContext;
        public MatchRepository(StatsCounterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateMatchAsync(Match match)
        {
            await _dbContext.Matches.AddAsync(match);
        }

        public async Task DeleteMatchAsync(int matchId)
        {
            var match = await _dbContext.Matches.SingleOrDefaultAsync(m => m.Id == matchId);

            _dbContext.Matches.Remove(match);
        }

        public async Task<List<Match>> GetAllMatchesByPlayerIdAsync(int playerId)
        {
            return await _dbContext.Matches
                .Where(m=> m.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<Match> GetMByIdAsync(int matchId)
        {
            return await _dbContext.Matches.Include(m => m.Player).SingleOrDefaultAsync(m => m.Id == matchId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
