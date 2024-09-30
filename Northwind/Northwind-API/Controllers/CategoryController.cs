using Microsoft.AspNetCore.Mvc;
using Northwind_API.Interfaces;

namespace Northwind_API.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _categoryRepository.GetImage(id);
            return File(image, "image/png");
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateImage(int id, [FromForm] IFormFile file)
        {
            await _categoryRepository.UpdateImage(id, file);
            return NoContent();
        }
    }
}
