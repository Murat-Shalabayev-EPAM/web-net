using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using NorthWind.Data;
using NorthWind.Models;
using NorthWind.Models.ViewModels;

namespace NorthWind.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        public ProductController(ApplicationDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var createVM = await _productRepository.Upsert(id);
            if (createVM.Product == null) return NotFound();
            return View(createVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Upsert(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
