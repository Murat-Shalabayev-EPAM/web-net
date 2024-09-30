using System.ComponentModel.DataAnnotations;

namespace Northwind_API.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        [Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }
        [Range(0, short.MaxValue)]
        public short UnitsOnOrder { get; set; }
        [Range(0, short.MaxValue)]
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
