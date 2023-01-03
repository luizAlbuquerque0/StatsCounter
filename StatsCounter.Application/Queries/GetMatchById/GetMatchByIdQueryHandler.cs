using MediatR;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Queries.GetMatchById
{
    public class GetMatchByIdQueryHandler : IRequestHandler<GetMatchByIdQuery, Match>
    {
        private readonly IMatchRepository _matchRepository;
        public GetMatchByIdQueryHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        public async Task<Match> Handle(GetMatchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _matchRepository.GetMByIdAsync(request.Id);
        }
    }
}
