using Futebol.Domain.Commands;
using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.Repositories;
using MediatR;

namespace Futebol.Domain.Handlers
{
    public class ConsultarTimeCommandHandler 
    : IRequestHandler<ConsultarTimeCommand, ConsultarTimeResponse>
    {
        private readonly ITimeRepository _repository;
        private readonly NotificationContext _notificationContext;

        public ConsultarTimeCommandHandler(
            ITimeRepository repository,
            NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<ConsultarTimeResponse> Handle(
            ConsultarTimeCommand request, 
            CancellationToken cancellationToken)
        {
            var time = await _repository.GetByIdAsync(request.Id);

            if (time is null)
            {
                _notificationContext.AddNotification("Erro", "Time não encontrado.");
                return default;
            }

            return ConsultarTimeResponse.Map(time);
        }
    }
}