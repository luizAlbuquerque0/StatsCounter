using FluentValidation;
using StatsCounter.Application.Commands.CreateMatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsCounter.Application.Validators
{
    public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
        {
            RuleFor(m => m.PlayerId)
                .NotEmpty()
                .WithMessage("O id do player é obrigatório");

            RuleFor(m => m.Date)
                .NotEmpty()
                .WithMessage("A data da partida é obrigatória");
        }
    }
}
