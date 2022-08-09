using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.ProductAPI.DbContexts;
using Mongo.Services.ProductAPI.Models;
using Mongo.Services.ProductAPI.Models.DTO;

namespace Mongo.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        IMapper _mapper;
        public ProductRepository(ApplicationDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext; 
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProdct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if(product.ProductId > 0 )
            {
                _dbContext.Update(product);
            }
            else
            {
                _dbContext.Add(product);
            }
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product); 
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _dbContext.Products.Where(s => s.ProductId == productId).FirstOrDefaultAsync();
                if (product != null)
                    return false;
                
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();    
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.Where(s => s.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProductDtosAsync()
        {
            IEnumerable<Product> productlist = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productlist);
        }
    }
}
