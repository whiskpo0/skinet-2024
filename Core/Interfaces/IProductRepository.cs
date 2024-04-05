using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int Id);
        Task<IReadOnlyList<Product>> GetProductsAsync();  
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();  
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();  
    }
}