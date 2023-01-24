using FluentValidation;
using StatsCounter.Application.Commands.CreatePlayer;
using System.Text.RegularExpressions;

namespace StatsCounter.Application.Validators
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email não válido");

            RuleFor(p => p.Password)
                .Must(validPassword)
                .WithMessage("Senha deve conter no mínimo 8 caracteres, um numero, um caracter especial e uma letra maiúscula");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório");
        }

        public bool validPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
