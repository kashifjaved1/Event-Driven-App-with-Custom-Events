using EventDrivenCrudApp.Repositories.Interfaces;

namespace EventDrivenCrudApp.Repositories.Implementation
{
    /// <summary>
    /// In-memory implementation of the IProductRepository.
    /// Used to store and manage product entities without persistence.
    /// </summary>
    public class InMemoryProductRepository : IProductRepository
    {
        // Internal dictionary to store products with their unique ID as the key
        private readonly Dictionary<Guid, Product> _products = new();

        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void Add(Product product)
        {
            // Insert or replace the product by its ID
            _products[product.Id] = product;
        }

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The updated product object.</param>
        public void Update(Product product)
        {
            // Only update if the product already exists
            if (_products.ContainsKey(product.Id))
            {
                _products[product.Id] = product;
            }
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        public void Delete(Guid id)
        {
            // Remove the product from the dictionary if it exists
            _products.Remove(id);
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product if found; otherwise, null.</returns>
        public Product Get(Guid id)
        {
            // Try to get the product; return null if not found
            return _products.TryGetValue(id, out var product) ? product : null;
        }

        /// <summary>
        /// Retrieves all stored products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public IEnumerable<Product> GetAll()
        {
            // Return a list of all values from the dictionary
            return _products.Values.ToList();
        }
    }
}
