using Microsoft.EntityFrameworkCore;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using NorthWind.Data;

namespace Northwind.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var categories = _context.Categories.Select(x => new CategoryViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            });

            return await categories.ToListAsync();
        }
    }
}
