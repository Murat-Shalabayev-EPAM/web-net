using Microsoft.EntityFrameworkCore;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using NorthWind.Data;
using NorthWind.Models;

namespace Northwind.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryViewModel> Edit(int id)
        {
            var vm = await _context.Categories.Select(x => new CategoryViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture
            }).FirstOrDefaultAsync(x => x.CategoryID == id);
            return vm;
        }

        public async Task Edit(CategoryViewModel viewModel)
        {
            var model = await _context.Categories.FindAsync(viewModel.CategoryID);
            if (model == null)
            {
                return;
            }

            model.CategoryName = viewModel.CategoryName;
            model.Description = viewModel.Description;
            model.Picture = viewModel.Picture;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var categories = _context.Categories.Select(x => new CategoryViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture,
            });

            return await categories.ToListAsync();
        }

        public async Task<byte[]> ReturnImage(int id)
        {
            return await _context.Categories.Where(x => x.CategoryID == id).Select(x => x.Picture).FirstOrDefaultAsync();
        }
    }
}
