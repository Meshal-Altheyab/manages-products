using ProductMvc.Data;
using ProductMvc.Models;
using Microsoft.Extensions.Logging;

namespace ProductMvc.Repositories
{
    public class ProductRepository : IRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddProduct(Product product)
        {
            _logger.LogInformation("Adding product {Name}", product.Name);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts() => _context.Products.ToList();

        public void UpdateProduct(Product product)
        {
            var existing = _context.Products.Find(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                _context.SaveChanges();
                _logger.LogInformation("Updated product {Id}", product.Id);
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                _logger.LogWarning("Deleted product {Id}", id);
            }
        }
    }
}
