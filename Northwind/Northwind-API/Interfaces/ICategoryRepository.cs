using Northwind_API.Models.Dtos;

namespace Northwind_API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategories();
        Task<byte[]> GetImage(int id);
        Task UpdateImage(int id, IFormFile file);
    }
}
