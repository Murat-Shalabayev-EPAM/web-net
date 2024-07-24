using Microsoft.AspNetCore.Mvc;
using Northwind_API.Interfaces;
using Northwind_API.Models.Dtos;

namespace Northwind_API.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _repository.Create(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(id, dto));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
