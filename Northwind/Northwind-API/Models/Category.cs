using System.ComponentModel.DataAnnotations;

namespace Northwind_API.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture {  get; set; }
    }
}
