using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWind.Data;
using Northwind_API.Interfaces;
using Northwind_API.Models.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace Northwind_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _context.Categories.Select(x => new CategoryDto
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToListAsync();
        }

        public async Task<byte[]> GetImage(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category.Picture;
        }

        public async Task UpdateImage(int id, IFormFile file)
        {
            var category = await _context.Categories.FindAsync(id);
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                category.Picture = memoryStream.ToArray();
            }

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
