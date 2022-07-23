using Futebol.Domain.Commands;
using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.Entities;
using Futebol.Domain.Repositories;
using MediatR;

namespace Futebol.Domain.Handlers
{
    public class DeletarTimeCommandHandler 
    : IRequestHandler<DeletarTimeCommand>
    {
        private readonly ITimeRepository _repository;
        private readonly INotificationContext _notificationContext;

        public DeletarTimeCommandHandler(
            ITimeRepository repository,
            INotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<Unit> Handle(DeletarTimeCommand request, CancellationToken cancellationToken)
        {
            var timeExistente = await _repository.ObterPorIdAsync(request.Id);

            if (timeExistente is default(Time))
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao deletar o time.", 
                    "Time não encontrado na base de dados.");

                return default;
            }

            await _repository.ExcluirAsync(timeExistente);

            if (_notificationContext.HasNotifications)
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao deletar o time.", 
                    "Erro ao deletar o time no banco de dados.");

                return default;
            }

            return Unit.Value;
        }
    }
}