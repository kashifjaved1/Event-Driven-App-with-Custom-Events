using EventDrivenCrudApp.Events;
using EventDrivenCrudApp.Repositories.Implementation;
using EventDrivenCrudApp.Repositories.Interfaces;

namespace EventDrivenCrudApp.Handlers
{
    /// <summary>
    /// Handles product deletion events by removing the product from the repository.
    /// </summary>
    public class ProductDeletedHandler
    {
        /// <summary>
        /// Subscribes to ProductDeletedEvent and deletes the corresponding product from the repository.
        /// </summary>
        /// <param name="bus">The event bus used to subscribe to events.</param>
        /// <param name="repo">The product repository used for data access.</param>
        public ProductDeletedHandler(IEventBus bus, IProductRepository repo)
        {
            // Subscribe to ProductDeletedEvent on the event bus
            bus.Subscribe<ProductDeletedEvent>(e =>
            {
                // When the event is received, delete the product with the given ID from the repository
                repo.Delete(e.ProductId);
            });
        }
    }
}