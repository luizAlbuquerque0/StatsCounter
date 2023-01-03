using MediatR;
using StatsCounter.Application.ViewModels;

namespace StatsCounter.Application.Queries.GetPlayerStats
{
    public class GetPlayerStatsQuery : IRequest<ProfileViewModel>
    {
        public GetPlayerStatsQuery(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; private set; }
    }
}
