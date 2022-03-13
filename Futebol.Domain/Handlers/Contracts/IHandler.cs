using Futebol.Domain.Commands.Contracts;

namespace Futebol.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T: ICommand 
    {
        ICommandResult Handle(T command);
    }
}