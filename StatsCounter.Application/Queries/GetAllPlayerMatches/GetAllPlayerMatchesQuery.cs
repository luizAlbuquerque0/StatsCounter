using MediatR;
using StatsCounter.Application.ViewModels;
using StatsCounter.Core.Entities;

namespace StatsCounter.Application.Queries.GetAllPlayerMatches
{
    public class GetAllPlayerMatchesQuery : IRequest<List<MatchDetailsViewModel>>
    {
        public GetAllPlayerMatchesQuery(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; private set; }
    }
}



