using StatsCounter.Core.Entities;

namespace StatsCounter.Core.Repositories
{
    public interface IMatchRepository
    {
        Task CreateMatchAsync(Match match);
        Task<List<Match>> GetAllMatchesByPlayerIdAsync(int playerId);
        Task DeleteMatchAsync(int matchId);
        Task<Match> GetMByIdAsync(int matchId);
        Task SaveChangesAsync();

    }
}
