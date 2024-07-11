using Microsoft.AspNetCore.Mvc;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
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

        public async Task<IActionResult> Edit(int id)
        {
            var categoryVM = await _repository.Edit(id);
            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        {
            if(viewModel == null)
            {
                return BadRequest();
            }

            await _repository.Edit(viewModel);
            return RedirectToAction("Index");
        }

        [Route("/images/{id}")] 
        public async Task<ActionResult> GetImage(int id)
        {
            var imageData = await _repository.ReturnImage(id);
            return File(imageData, "image/octet-stream");
        }
    }
}
