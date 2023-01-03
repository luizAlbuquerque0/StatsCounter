using StatsCounter.Core.Entities;

namespace StatsCounter.Core.Repositories
{
    public interface IPlayerRepository
    {
        Task CreatePlayerAsync(Player player);
        Task<Player> GetPlayerByEmailAndPasswordAsync(string email, string password);
        Task<Player> GetUserByIdAsync(int id);
    }
}
