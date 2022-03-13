using FluentValidation;

namespace Futebol.Domain.Commands
{
    public class DeletarTimeCommandValidator : AbstractValidator<DeletarTimeCommand>
    {
        public DeletarTimeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo '{PropertyName}' é obrigatório.");
        }
    }
}