using FluentValidation;
using StatsCounter.Application.Commands.UpdateMatch;

namespace StatsCounter.Application.Validators
{
    public class UpdateMatchCommandValidator : AbstractValidator<UpdateMatchCommand>
    {
        public UpdateMatchCommandValidator()
        {
            RuleFor(m => m.TochDowns)
                .NotEmpty()
                .WithMessage("A quantidade de tochdowns é obrigatória");

            RuleFor(m => m.MatchId)
                .NotEmpty()
                .WithMessage("O id da partida é obrigatório");

            RuleFor(m => m.AttemptedPasses)
                .NotEmpty()
                .WithMessage("A quantidade passes é obrigatória");

            RuleFor(m => m.CompletedPasses)
                .NotEmpty()
                .WithMessage("A quantidade passes certos é obrigatoria");

            RuleFor(m => m.Interceptations)
                .NotEmpty()
                .WithMessage("A quantidade de interceptações é obrigatoria");

            RuleFor(m => m.PassedYards)
                .NotEmpty()
                .WithMessage("A quantidade de jardas passadas é obrigatoria");
        }
    }
}
