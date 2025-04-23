using EventDrivenCrudApp.Repositories.Implementation;
using EventDrivenCrudApp.Repositories.Interfaces;

namespace EventDrivenCrudApp.Extensions
{
    /// <summary>
    /// Extension methods for configuring services in the application.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers application services and framework components into the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection Configuration(this IServiceCollection services)
        {
            // Register the event bus as a singleton so all event publishers and subscribers share the same instance
            services.AddSingleton<IEventBus, EventBus>();

            // Register the in-memory product repository for CRUD operations
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}