using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPatternAPI.Application.Repositories;
using RepositoryDesignPatternAPI.Domain.Entities;

namespace RepositoryDesignPatternAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        readonly private IOrderReadRepository _orderReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            ICustomerWriteRepository customerWriteRepository,
            ICustomerReadRepository customerReadRepository,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id=Guid.NewGuid(), Name="Product 1", Price=100, Stock= 25, CreateDate=DateTime.UtcNow },
            //    new() { Id=Guid.NewGuid(), Name="Product 2", Price=200, Stock= 35, CreateDate=DateTime.UtcNow },
            //    new() { Id=Guid.NewGuid(), Name="Product 3", Price=300, Stock= 45, CreateDate=DateTime.UtcNow },
            //    new() { Id=Guid.NewGuid(), Name="Product 4", Price=400, Stock= 15, CreateDate=DateTime.UtcNow },
            //});
            //var count = await _productWriteRepository.SaveAsync();

            //Product p = await _productReadRepository.GetByIdAsync("B6C47649-4B4B-49F7-8DF2-15F94E27ACF6");
            //p.Name = "Anahtarlık";
            //await _productWriteRepository.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id=customerId, Name = "Taha"},

            //});
            //await _customerWriteRepository.SaveAsync();

            Customer c = await _customerReadRepository.GetSingleAsync(x => x.Name == "Sado");
            c.Name = "Semih";
            await _customerWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
