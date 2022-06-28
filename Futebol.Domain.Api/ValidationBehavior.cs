// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using FluentValidation;
// using MediatR;

// namespace Futebol.Domain.Api
// {
//     public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
//     {
//         public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, INotification)
//         public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);

//     }
// }