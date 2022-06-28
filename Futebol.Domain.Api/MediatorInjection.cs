using System.Reflection;
using FluentValidation;
using MediatR;

namespace Futebol.Domain.Api
{
    public static class MediatorInjection
    {
        private static Assembly DomainAssembly => AppDomain.CurrentDomain.Load("Futebol.Domain");

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(DomainAssembly);

            AssemblyScanner
                .FindValidatorsInAssembly(DomainAssembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}