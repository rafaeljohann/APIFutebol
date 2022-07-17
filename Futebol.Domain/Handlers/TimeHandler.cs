// using FluentValidation.Results;
// using Futebol.Domain.Commands;
// using Futebol.Domain.Commands.Contracts;
// using Futebol.Domain.Entities;
// using Futebol.Domain.Handlers.Contracts;
// using Futebol.Domain.Repositories;

// namespace Futebol.Domain.Handlers
// {
//     public class TimeHandler : IHandler<CriarTimeCommand>
//     {
//         private readonly ITimeRepository _repository;

//         public TimeHandler(ITimeRepository repository)
//         {
//             _repository = repository;
//         }

//         // public ICommandResult Handle(ConsultarTimeCommand command, long id)
//         // {
//         //     ConsultarTimeCommandValidator validator = new ConsultarTimeCommandValidator();
//         //     ValidationResult results = validator.Validate(command);

//         //     if (!results.IsValid)
//         //         return new GenericCommandResult(false, "Ocorreu algum problema ao consultar o time.", results.Errors);

//         //     var time = _repository.GetById(id);

//         //     if (time is null)
//         //         return new GenericCommandResult(false, "Não foi encontrado nenhum time para o id especificado.", results.Errors);

//         //     return new GenericCommandResult(true, "Time consultado com sucesso!", time);
//         // }

//         public ICommandResult Handle(CriarTimeCommand command)
//         {
//             var validator = new CriarTimeCommandValidator();
//             var result = validator.Validate(command);

//             if (!result.IsValid)
//                 return new GenericCommandResult(false, "Ocorreu algum problema ao criar o time.", result.Errors);

//             var time = new Time(command.Nome, command.DataFundacao, command.NomePresidente, command.NomeMascote, command.Cidade, command.Estado, command.Pais);
//             _repository.Create(time);

//             return new GenericCommandResult(true, "Time criado!", time);
//         }

//         public ICommandResult Handle(AtualizarTimeCommand command)
//         {
//             AtualizarTimeCommandValidator validator = new AtualizarTimeCommandValidator();
//             ValidationResult results = validator.Validate(command);

//             if (!results.IsValid)
//                 return new GenericCommandResult(false, "Ocorreu algum problema ao atualizar o time.", results.Errors);

//             var time = new Time(command.Nome, command.DataFundacao, command.NomePresidente, command.NomeMascote, command.Cidade, command.Estado, command.Pais);
//             _repository.Update(time);

//             return new GenericCommandResult(true, "Time atualizado!", time);
//         }

//         // public ICommandResult Handle(DeletarTimeCommand command, long id)
//         // {
//         //     DeletarTimeCommandValidator validator = new DeletarTimeCommandValidator();
//         //     ValidationResult results = validator.Validate(command);

//         //     if (!results.IsValid)
//         //         return new GenericCommandResult(false, "Ocorreu algum problema ao deletar o time.", results.Errors);

//         //     var time = await _repository.GetById(id);

//         //     if (time == null)
//         //         return new GenericCommandResult(false, "Time inexistente.", results.Errors);
            
//         //     _repository.Delete(time);

//         //     return new GenericCommandResult(true, "Time excluído com sucesso!", time);
//         // }
//     }
// }