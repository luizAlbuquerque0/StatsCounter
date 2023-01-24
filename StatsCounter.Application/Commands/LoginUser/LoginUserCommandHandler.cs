using MediatR;
using StatsCounter.Application.ViewModels;
using StatsCounter.Core.Repositories;
using StatsCounter.Core.Services;

namespace StatsCounter.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IPlayerRepository playerRepository, IAuthService authService)
        {
            _playerRepository = playerRepository;
            _authService = authService;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var player = await _playerRepository.GetPlayerByEmailAndPasswordAsync(request.Email, passwordHash);
            if(player == null) return null;

            var token = _authService.GenerateJWTToken(player.Email);

            return new LoginUserViewModel(player.Email, token, player.Id);
        }
    }
}
