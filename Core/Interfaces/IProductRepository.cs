using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int Id);
        Task<IReadOnlyList<Product>> GetProductsAsync();  
    }
}