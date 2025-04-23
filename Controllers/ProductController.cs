using EventDrivenCrudApp.Events;
using EventDrivenCrudApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenCrudApp.Controllers
{
    /// <summary>
    /// API controller for managing product-related operations using an event-driven approach.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IEventBus _bus;
        private readonly IProductRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="bus">The event bus used to publish events.</param>
        /// <param name="repo">The product repository to access product data.</param>
        public ProductController(IEventBus bus, IProductRepository repo)
        {
            _bus = bus;
            _repo = repo;
        }

        /// <summary>
        /// Creates a new product by publishing a ProductCreatedEvent.
        /// </summary>
        /// <param name="product">The product data to create.</param>
        /// <returns>The created product with a generated ID.</returns>
        [HttpPost]
        public IActionResult Create(Product product)
        {
            // Generate a new unique ID for the incoming product
            product.Id = Guid.NewGuid();

            // Publish a product created event; actual saving will be handled by a subscribed event handler
            _bus.Publish(new ProductCreatedEvent { Product = product });

            // Return the product as confirmation of creation
            return Ok(product);
        }

        /// <summary>
        /// Updates an existing product by publishing a ProductUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>The updated product.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Product product)
        {
            // Make sure the product object uses the correct ID from the URL
            product.Id = id;

            // Publish a product updated event; event handler will update the product in storage
            _bus.Publish(new ProductUpdatedEvent { Product = product });

            // Return the updated product as confirmation
            return Ok(product);
        }

        /// <summary>
        /// Deletes a product by publishing a ProductDeletedEvent.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // Publish a deletion event; handler will remove the product from the repository
            _bus.Publish(new ProductDeletedEvent { ProductId = id });

            // Return 204 No Content to indicate success without a body
            return NoContent();
        }

        /// <summary>
        /// Retrieves a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product if found; otherwise, null.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            // Attempt to retrieve the product from the repository
            var product = _repo.Get(id);

            // Return the product (or null if not found)
            return Ok(product);
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            // Fetch all products from the in-memory repository
            var products = _repo.GetAll();

            // Return the collection
            return Ok(products);
        }
    }
}
