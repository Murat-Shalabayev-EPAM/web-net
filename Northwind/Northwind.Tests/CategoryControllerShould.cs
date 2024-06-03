using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using NorthWind.Controllers;

namespace Northwind.Tests
{
    public class CategoryControllerShould
    {
        private readonly CategoryController _controller;
        private readonly ICategoryRepository _repository;
        public CategoryControllerShould()
        {
            _repository = A.Fake<ICategoryRepository>();

            _controller = new CategoryController(_repository);
        }

        [Fact]
        public void Return_Category_ViewModels()
        {
            var categories = A.Fake<IEnumerable<CategoryViewModel>>();
            A.CallTo(() => _repository.GetAll()).Returns(categories);

            var result = _controller.Index();
            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}