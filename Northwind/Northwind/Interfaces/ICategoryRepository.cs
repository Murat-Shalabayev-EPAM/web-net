using Northwind.Models.ViewModels;

namespace Northwind.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> Edit(int id);
        Task Edit(CategoryViewModel viewModel);
        Task<byte[]> ReturnImage(int id);
    }
}
