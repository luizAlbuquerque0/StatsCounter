using MediatR;
using StatsCounter.Core.Entities;
using StatsCounter.Core.Repositories;
using StatsCounter.Core.Services;

namespace StatsCounter.Application.Commands.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IAuthService _authService;
        public CreatePlayerCommandHandler(IPlayerRepository playerRepository, IAuthService authService)
        {
            _playerRepository = playerRepository;
            _authService = authService;
        }
        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var player = new Player(request.Name, request.Email, passwordHash);
            await _playerRepository.CreatePlayerAsync(player);
            return player.Id;
        }
    }
}
