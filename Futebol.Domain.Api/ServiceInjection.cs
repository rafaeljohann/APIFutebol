using Futebol.Domain.CrossCutting.Notifications;
using Futebol.Domain.Handlers;
using Futebol.Domain.Infra.Repositories;
using Futebol.Domain.Repositories;

namespace Futebol.Domain.Api
{
    public static class ServiceInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Custom Services
            services.AddMediator();
            services.AddScoped<INotificationContext, NotificationContext>();

            // Repositories
            services.AddTransient<ITimeRepository, TimeRepository>();

            // Handlers
            services.AddScoped<ConsultarTimeCommandHandler, ConsultarTimeCommandHandler>();
            services.AddScoped<CriarTimeCommandHandler, CriarTimeCommandHandler>();
        }
    }
}