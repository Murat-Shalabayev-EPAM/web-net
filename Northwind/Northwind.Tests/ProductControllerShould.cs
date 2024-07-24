using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Controllers;
using Northwind.Interfaces;
using Northwind.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Models.ViewModels;
using FluentAssertions;

namespace Northwind.Tests
{
    public class ProductControllerShould
    {
        private readonly ProductController _controller;
        private readonly IProductRepository _repository;
        public ProductControllerShould()
        {
            _repository = A.Fake<IProductRepository>();

            _controller = new ProductController(_repository);
        }

        [Fact]
        public void Return_Product_ViewModels()
        {
            var products = A.Fake<IEnumerable<ProductViewModel>>();
            A.CallTo(() => _repository.GetAll()).Returns(products);

            var result = _controller.Index();
            result.Should().BeOfType<Task<ActionResult>>();
        }
    }
}
