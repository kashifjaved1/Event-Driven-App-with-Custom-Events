using EventDrivenCrudApp.Events;
using EventDrivenCrudApp.Repositories.Interfaces;

namespace EventDrivenCrudApp.Handlers
{
    /// <summary>
    /// Handles product update events by updating the product in the repository.
    /// </summary>
    public class ProductUpdatedHandler
    {
        /// <summary>
        /// Subscribes to ProductUpdatedEvent and updates the product in the repository when the event is published.
        /// </summary>
        /// <param name="bus">The event bus used to subscribe to events.</param>
        /// <param name="repo">The repository to update product data.</param>
        public ProductUpdatedHandler(IEventBus bus, IProductRepository repo)
        {
            // Subscribe to the ProductUpdatedEvent using the event bus
            bus.Subscribe<ProductUpdatedEvent>(e =>
            {
                // Update the product in the repository with the new data from the event
                repo.Update(e.Product);
            });
        }
    }
}