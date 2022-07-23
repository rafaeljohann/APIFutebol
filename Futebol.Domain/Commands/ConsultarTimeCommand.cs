using Futebol.Domain.Commands.Responses;
using MediatR;

namespace Futebol.Domain.Commands
{
    public class ConsultarTimeCommand : IRequest<ConsultarTimeResponse>
    {
        public int Id { get; init; }
        public ConsultarTimeCommand(int id) {
            Id = id;
        }
    }
}