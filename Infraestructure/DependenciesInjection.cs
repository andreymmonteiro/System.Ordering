using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Data;
using Order.Domain.Data.Connections;
using Order.Domain.Data.UnitOfWork;
using Order.Infraestructure.Data.Connections;
using Order.Infraestructure.Data.UnitOfWork;

namespace Order.Infraestructure
{
    public static class DependenciesInjection
    {
        public static IServiceCollection AddInfraestructureDependencies(this IServiceCollection services, IConfig config)
        {
            services.AddSingleton(config);
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
