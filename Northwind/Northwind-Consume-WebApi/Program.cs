using Northwind_Consume_WebApi.Models;
using System.Net.Http.Json;

namespace Northwind_Consume_WebApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://localhost:7228/";
            
            using (var client = new HttpClient())
            {
                try
                {
                    List<Category> categories = await client.GetFromJsonAsync<List<Category>>($"{url}Category/api");
                    List<Product> products = await client.GetFromJsonAsync<List<Product>>($"{url}Product/api");
                    foreach (var category in categories)
                    {
                        Console.WriteLine(category.CategoryName);
                    }
                    foreach (var product in products)
                    {
                        Console.WriteLine(product.ProductName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
