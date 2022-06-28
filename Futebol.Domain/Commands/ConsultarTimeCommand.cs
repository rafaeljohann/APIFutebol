using MediatR;

namespace Futebol.Domain.Commands
{
    public class ConsultarTimeCommand : IRequest<ConsultarTimeResponse>
    {
        public long Id { get; init; }
        public ConsultarTimeCommand(long id) {
            Id = id;
        }
    }
}