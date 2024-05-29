using Northwind.Models.ViewModels;

namespace Northwind.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<byte[]> ReturnImage(int id);
    }
}
