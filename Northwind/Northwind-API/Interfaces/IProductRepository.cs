using Northwind_API.Models.Dtos;

namespace Northwind_API.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProducts();
        Task<int> Create(CreateProductDto dto);
        Task<ProductDto> Update(int id, CreateProductDto dto);
        void Delete(int id);
    }
}
