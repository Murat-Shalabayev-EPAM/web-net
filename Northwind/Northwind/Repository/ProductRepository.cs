using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using NorthWind.Data;
using NorthWind.Models;
using NorthWind.Models.ViewModels;

namespace Northwind.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
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
            });

            return productViewModels;
        }

        public async Task<CreateProductViewModel> Upsert(int? id)
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

            if (id == null)
            {
                return createVM;
            }
            else
            {
                createVM.Product = await _context.Products.FindAsync(id);
                return createVM;
            }
        }

        public async Task Upsert(CreateProductViewModel model)
        {
            if (model.Product.ProductID == 0)
            {
                await _context.Products.AddAsync(model.Product);
            }
            else
            {
                var product = await _context.Products.FindAsync(model.Product.ProductID);
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
        }
    }
}
