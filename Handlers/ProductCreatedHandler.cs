using EventDrivenCrudApp.Events;
using EventDrivenCrudApp.Repositories.Interfaces;

namespace EventDrivenCrudApp.Handlers
{
    /// <summary>
    /// Handles product creation events by saving the new product to the repository.
    /// </summary>
    public class ProductCreatedHandler
    {
        /// <summary>
        /// Subscribes to ProductCreatedEvent and adds the product to the repository when the event is triggered.
        /// </summary>
        /// <param name="bus">The event bus used to subscribe to events.</param>
        /// <param name="repo">The repository to store the product.</param>
        public ProductCreatedHandler(IEventBus bus, IProductRepository repo)
        {
            // Subscribe to ProductCreatedEvent using the event bus.
            // When the event is published, this handler will be triggered.

            bus.Subscribe<ProductCreatedEvent>(e =>
            {
                // Extract the product from the event and add it to the repository.
                // This is the point where the product is persisted (e.g., in memory or in a database).
                repo.Add(e.Product);
            });
        }
    }
}