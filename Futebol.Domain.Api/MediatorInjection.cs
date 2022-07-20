using FluentValidation;
using Futebol.Domain.CrossCutting.ValidationBehavior;
using MediatR;

namespace Futebol.Domain.Api
{
    public static class MediatorInjection
    {
        public static void AddMediator(this IServiceCollection services)
        {
            const string applicationAssemblyName = "Futebol.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddMediatR(assembly);
        }
    }
}