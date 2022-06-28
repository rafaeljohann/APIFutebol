using FluentValidation.Results;
using Futebol.Domain.Commands;
using Futebol.Domain.Repositories;
using MediatR;

namespace Futebol.Domain.Handlers
{
    public class ConsultarTimeHandler : IRequestHandler<ConsultarTimeCommand, ConsultarTimeResponse>
    {
        private readonly ITimeRepository _repository;

        public ConsultarTimeHandler(ITimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConsultarTimeResponse> Handle(
            ConsultarTimeCommand request, 
            CancellationToken cancellationToken)
        {
            var validator = new ConsultarTimeCommandValidator();
            var results = validator.Validate(request);

            if (!results.IsValid)
                return default(ConsultarTimeResponse);

            var time = await _repository.GetByIdAsync(request.Id);

            if (time is null)
            {
                results.Errors.Add(new ValidationFailure("Time", "Time não encontrado."));
                return default;
            }

            return ConsultarTimeResponse.Map(time);
        }
    }
}