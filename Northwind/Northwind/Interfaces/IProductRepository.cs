using Northwind.Models.ViewModels;
using NorthWind.Models.ViewModels;

namespace Northwind.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<CreateProductViewModel> Upsert(int? id);
        Task Upsert(CreateProductViewModel model);
    }
}
