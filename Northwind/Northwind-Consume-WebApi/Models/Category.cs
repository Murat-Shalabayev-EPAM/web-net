using System.ComponentModel.DataAnnotations;

namespace Northwind_Consume_WebApi.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
