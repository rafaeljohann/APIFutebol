using MediatR;

namespace Futebol.Domain.Commands
{
    public class DeletarTimeCommand : IRequest
    {
        public int Id { get; init; }

        public DeletarTimeCommand(int id)
        {
            Id = id;
        }
    }
}