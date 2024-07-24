using Microsoft.EntityFrameworkCore;
using NorthWind.Data;
using Northwind_API.Extesnsions;
using Northwind_API.Interfaces;
using Northwind_API.Models;
using Northwind_API.Models.Dtos;

namespace Northwind_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .Select(x => x.ToProductDto(x.Category.CategoryName))
                .ToListAsync();

            return products;
        }

        public async Task<int> Create(CreateProductDto dto)
        {
            var model = new Product()
            {
                ProductName = dto.ProductName,
                CategoryID = dto.CategoryId,
                QuantityPerUnit = dto.QuantityPerUnit,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                UnitsOnOrder = dto.UnitsOnOrder,
                ReorderLevel = dto.ReorderLevel,
                Discontinued = dto.Discontinued
            };

            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.ProductID;
        }

        public void Delete(int id)
        {
            var model = _context.Products.Find(id);
            _context.Products.Remove(model);
            _context.SaveChanges();
        }

        

        public async Task<ProductDto> Update(int id, CreateProductDto dto)
        {
            var model = await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ProductID == id);
            model.ProductName = dto.ProductName;
            model.CategoryID = dto.CategoryId;
            model.QuantityPerUnit = dto.QuantityPerUnit;
            model.UnitPrice = dto.UnitPrice;
            model.UnitsInStock = dto.UnitsInStock;
            model.UnitsOnOrder = dto.UnitsOnOrder;
            model.ReorderLevel = dto.ReorderLevel;
            model.Discontinued = dto.Discontinued;
            await _context.SaveChangesAsync();

            return model.ToProductDto(model.Category.CategoryName);
        }
    }
}
