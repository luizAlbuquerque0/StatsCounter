using MediatR;
using StatsCounter.Application.ViewModels;
using StatsCounter.Core.Repositories;

namespace StatsCounter.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IPlayerRepository _playerRepository;
        public LoginUserCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetPlayerByEmailAndPasswordAsync(request.Email, request.Password);
            if(player == null) return null;

            return new LoginUserViewModel(player.Email, "token", player.Id);
        }
    }
}
