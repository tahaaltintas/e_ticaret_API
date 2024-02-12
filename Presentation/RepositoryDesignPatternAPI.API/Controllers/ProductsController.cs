using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPatternAPI.Application.Repositories;

namespace RepositoryDesignPatternAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(), Name="Product 1", Price=100, Stock= 25, CreateDate=DateTime.UtcNow },
                new() { Id=Guid.NewGuid(), Name="Product 2", Price=200, Stock= 35, CreateDate=DateTime.UtcNow },
                new() { Id=Guid.NewGuid(), Name="Product 3", Price=300, Stock= 45, CreateDate=DateTime.UtcNow },
                new() { Id=Guid.NewGuid(), Name="Product 4", Price=400, Stock= 15, CreateDate=DateTime.UtcNow },
            });
            var count = await _productWriteRepository.SaveAsync();
        }
    }
}
