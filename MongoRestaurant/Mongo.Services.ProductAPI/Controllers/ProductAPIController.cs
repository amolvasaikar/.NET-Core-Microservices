using Microsoft.AspNetCore.Mvc;
using Mongo.Services.ProductAPI.Models.DTO;
using Mongo.Services.ProductAPI.Repository;

namespace Mongo.Services.ProductAPI.Controllers

{
    [Route("api/product")]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        ResponceDto responceDto = null;
        public ProductAPIController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            responceDto = new ResponceDto();

        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var productDto = await _productRepository.GetProductDtosAsync();
                responceDto.Result = productDto;
            }
            catch (Exception ex)
            {
                responceDto.IsSucess = false;
                responceDto.ErrorMessages = new List<string> { ex.Message };
            }
            return responceDto;
        }

        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var productDto = await _productRepository.GetProductByIdAsync(id);
                responceDto.Result = productDto;
            }
            catch (Exception ex)
            {
                responceDto.IsSucess = false;
                responceDto.ErrorMessages = new List<string> { ex.Message };
            }
            return responceDto;
        }

        [HttpPost()]
        public async Task<object> Post([FromBody] ProductDto productdto)
        {
            try
            {
                var productDto = await _productRepository.CreateUpdateProdct(productdto);
                responceDto.Result = productDto;
            }
            catch (Exception ex)
            {
                responceDto.IsSucess = false;
                responceDto.ErrorMessages = new List<string> { ex.Message };
            }
            return responceDto;
        }

        [HttpPut()]
        public async Task<object> Put([FromBody] ProductDto productdto)
        {
            try
            {
                var productDto = await _productRepository.CreateUpdateProdct(productdto);
                responceDto.Result = productDto;
            }
            catch (Exception ex)
            {
                responceDto.IsSucess = false;
                responceDto.ErrorMessages = new List<string> { ex.Message };
            }
            return responceDto;
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var result = await _productRepository.DeleteProduct(id);
                responceDto.Result = result;
            }
            catch (Exception ex)
            {
                responceDto.IsSucess = false;
                responceDto.ErrorMessages = new List<string> { ex.Message };
            }
            return responceDto;
        }
    }
}
