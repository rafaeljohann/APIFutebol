using FluentValidation;

namespace Futebol.Domain.Commands
{
    public class AtualizarTimeCommandValidator : AbstractValidator<AtualizarTimeCommand>
    {
        public AtualizarTimeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.");
            RuleFor(x => x.Nome).Length(3, 100).WithMessage("O campo '{PropertyName}' precisa conter entre 3 e 100 caracteres.");
            RuleFor(x => x.DataFundacao).NotNull().WithMessage("O campo '{PropertyName}' é obrigatório.");
            RuleFor(x => x.NomePresidente).Length(3, 60).WithMessage("O campo '{PropertyName}' precisa conter entre 3 e 60 caracteres.");
            RuleFor(x => x.Cidade).Length(3, 60).WithMessage("O campo '{PropertyName}' precisa conter entre 3 e 60 caracteres.");
            RuleFor(x => x.Estado).Length(2).WithMessage("O campo '{PropertyName}' precisa conter 2 caracteres.");
            RuleFor(x => x.Pais).Length(3, 60).WithMessage("O campo '{PropertyName}' precisa conter entre 3 e 60 caracteres.");
        }
    }
}