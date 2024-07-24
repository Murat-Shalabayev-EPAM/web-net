using Northwind_API.Models;
using Northwind_API.Models.Dtos;

namespace Northwind_API.Extesnsions
{
    public static class ProductExtensions
    {
        public static ProductDto ToProductDto(this Product model, string categoryName) => model == null ? null :
        new ProductDto
        {

            Id = model.ProductID,
            ProductName = model.ProductName,
            CategoryName = categoryName,
            QuantityPerUnit = model.QuantityPerUnit,
            UnitPrice = model.UnitPrice,
            UnitsInStock = model.UnitsInStock,
            UnitsOnOrder = model.UnitsOnOrder,
            ReorderLevel = model.ReorderLevel,
            Discontinued = model.Discontinued
        };
    }
}
