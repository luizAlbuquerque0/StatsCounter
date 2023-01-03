using MediatR;
using StatsCounter.Core.Entities;

namespace StatsCounter.Application.Queries.GetMatchById
{
    public class GetMatchByIdQuery : IRequest<Match>
    {
        public GetMatchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
