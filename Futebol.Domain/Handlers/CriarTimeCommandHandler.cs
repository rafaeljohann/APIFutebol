using Futebol.Domain.Commands;
using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.Entities;
using Futebol.Domain.Repositories;
using MediatR;

namespace Futebol.Domain.Handlers
{
    public class CriarTimeCommandHandler 
    : IRequestHandler<CriarTimeCommand>
    {
        private readonly ITimeRepository _repository;
        private readonly NotificationContext _notificationContext;

        public CriarTimeCommandHandler(
            ITimeRepository repository,
            NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<Unit> Handle(CriarTimeCommand request, CancellationToken cancellationToken)
        {
            var timeExistente = await _repository.ObterPorNomeAsync(request.Nome);

            if (timeExistente is not default(Time))
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao criar o time.", 
                    "Time já existente na base de dados.");

                return default;
            }

            var time = new Time(
                request.Nome,
                request.DataFundacao,
                request.NomePresidente,
                request.NomeMascote,
                request.Cidade,
                request.Estado,
                request.Pais
            );

            await _repository.CriarAsync(time);

            if (_notificationContext.HasNotifications)
            {
                _notificationContext.AddNotification(
                    "Ocorreu um erro ao criar o time.", 
                    "Erro ao salvar o time no banco de dados.");

                return default;
            }

            return Unit.Value;
        }
    }
}