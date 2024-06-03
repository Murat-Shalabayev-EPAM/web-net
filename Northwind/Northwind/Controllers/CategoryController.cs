using Microsoft.AspNetCore.Mvc;
using Northwind.Interfaces;
using System.Text;

namespace NorthWind.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _repository.GetAll();
            return View(categories);
        }

        [Route("/images/{id}")] 
        public async Task<ActionResult> GetImage(int id)
        {
            var imageData = await _repository.ReturnImage(id);
            return File(imageData, "image/octet-stream");
        }
    }
}
