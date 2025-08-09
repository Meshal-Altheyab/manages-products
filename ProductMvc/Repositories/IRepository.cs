using ProductMvc.Models;

namespace ProductMvc.Repositories
{
    public interface IRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
