using Futebol.Domain.Commands;
using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.Entities;
using Futebol.Domain.Repositories;
using MediatR;

namespace Futebol.Domain.Handlers
{
    public class AtualizarTimeCommandHandler 
    : IRequestHandler<AtualizarTimeCommand>
    {
        private readonly ITimeRepository _repository;
        private readonly INotificationContext _notificationContext;

        public AtualizarTimeCommandHandler(
            ITimeRepository repository,
            INotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<Unit> Handle(AtualizarTimeCommand request, CancellationToken cancellationToken)
        {
            var timeExistente = await _repository.ObterPorIdAsync(request.Id);

            if (timeExistente is default(Time))
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao atualizar o time.", 
                    "Time não encontrado na base de dados.");

                return default;
            }

            timeExistente.AtualizarInformacoesTime(
                request.Nome,
                request.DataFundacao,
                request.NomePresidente,
                request.NomeMascote,
                request.Cidade,
                request.Estado,
                request.Pais);

            await _repository.AtualizarAsync(timeExistente);

            if (_notificationContext.HasNotifications)
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao atualizar o time.", 
                    "Erro ao atualizar o time no banco de dados.");

                return default;
            }

            return Unit.Value;
        }
    }
}