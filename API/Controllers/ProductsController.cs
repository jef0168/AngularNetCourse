using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Queries;
using Core.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _mediator.Send(new GetProducts.Query());
            return products == null ? NotFound() : Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductsById.Query(id));

            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProduct(AddProduct.Command command) => Ok(await _mediator.Send(command));
    }
}