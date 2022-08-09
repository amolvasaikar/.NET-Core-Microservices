using Mongo.Services.ProductAPI.Models.DTO;

namespace Mongo.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductDtosAsync();    

        Task<ProductDto> GetProductByIdAsync(int id);

        Task<ProductDto> CreateUpdateProdct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);
    }
}
