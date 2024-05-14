using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Models.ViewModels;
using NorthWind.Data;
using NorthWind.Models;
using NorthWind.Models.ViewModels;

namespace NorthWind.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ProductController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var pageSize = _configuration.GetValue<int>("PAGE_SIZE");
            var products = await _context.Products
                                    .Include(x => x.Category)
                                    .Include(x => x.Supplier)
                                    .ToListAsync();
            var productViewModels = products.Select(x => new ProductViewModel
            {
                Id = x.ProductID,
                ProductName = x.ProductName, 
                SupplierName = x.Supplier.CompanyName,
                CategoryName = x.Category.CategoryName,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            }).Take(pageSize != 0 ? pageSize : products.Count);
            return View(productViewModels);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var createVM = new CreateProductViewModel()
            {
                Product = new Product(),
                SupplierSelectList = _context.Suppliers.Select(x => new SelectListItem
                {
                    Text = x.CompanyName,
                    Value = x.SupplierID.ToString()
                }),
                CategorySelectList = _context.Categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
            };

            if(id == null)
            {
                return View(createVM);
            }
            else
            {
                createVM.Product = await _context.Products.FindAsync(id);
                if (createVM.Product == null) return NotFound();
                return View(createVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Product.ProductID == 0)
                {
                    await _context.Products.AddAsync(model.Product);
                }
                else
                {
                    var product = await _context.Products.FindAsync(model.Product.ProductID);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    product.SupplierID = model.Product.SupplierID;
                    product.CategoryID = model.Product.CategoryID;
                    product.QuantityPerUnit = model.Product.QuantityPerUnit;
                    product.UnitPrice = model.Product.UnitPrice;
                    product.UnitsInStock = model.Product.UnitsInStock;
                    product.UnitsOnOrder = model.Product.UnitsOnOrder;
                    product.ReorderLevel = model.Product.ReorderLevel;
                    product.Discontinued = model.Product.Discontinued;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
