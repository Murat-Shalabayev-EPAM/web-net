using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.Models;

namespace Northwind.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> SupplierSelectList { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
