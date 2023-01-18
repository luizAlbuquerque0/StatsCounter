using MediatR;
using StatsCounter.Application.ViewModels;

namespace StatsCounter.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
