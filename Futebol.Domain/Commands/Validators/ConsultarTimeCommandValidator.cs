using FluentValidation;

namespace Futebol.Domain.Commands.Validators
{
    public class ConsultarTimeCommandValidator : AbstractValidator<ConsultarTimeCommand>
    {
        public ConsultarTimeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo '{PropertyName}' é obrigatório.");
        }
    }
}