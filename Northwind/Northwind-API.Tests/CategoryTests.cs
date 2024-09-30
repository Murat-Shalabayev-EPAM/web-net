using FluentAssertions;
using Moq;
using Northwind_API.Controllers;
using Northwind_API.Interfaces;
using Northwind_API.Models;
using Northwind_API.Models.Dtos;

namespace Northwind_API.Tests
{
    public class CategoryTests
    {
        private List<CategoryDto> _categories;
        public CategoryTests()
        {
            _categories = new List<CategoryDto>()
            {
                new CategoryDto
                {
                    CategoryID = 1,
                    CategoryName = "testName",
                    Description = "testDesc",
                }
            };
        }

        [Fact]
        public async Task ReturnCategories()
        {
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository.Setup(client => client.GetCategories()).ReturnsAsync(_categories);
            var controller = new CategoryController(mockRepository.Object);

            var result = await controller.GetCategories();

            result.Should().NotBeNull();
        }

    }
}