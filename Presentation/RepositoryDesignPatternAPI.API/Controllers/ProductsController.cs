using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPatternAPI.Application.Features.Commands.Product.CreateProduct;
using RepositoryDesignPatternAPI.Application.Features.Commands.Product.RemoveProduct;
using RepositoryDesignPatternAPI.Application.Features.Commands.Product.UpdateProduct;
using RepositoryDesignPatternAPI.Application.Features.Queries.Product.GetAllProduct;
using RepositoryDesignPatternAPI.Application.Features.Queries.Product.GetByIdProduct;
using RepositoryDesignPatternAPI.Application.Repositories;


namespace RepositoryDesignPatternAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductReadRepository _productReadRepository;

        readonly IMediator _mediator;

        public ProductsController(IMediator mediator, IProductReadRepository productReadRepository = null)
        {
            _mediator = mediator;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var productsTask = _productReadRepository.GetAll(false);

            var products = await productsTask;


            var selectedProducts = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreateDate,
                p.UpdateDate
            }).ToList();

            return Ok(selectedProducts); 
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommondRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommondRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }


    }
}
