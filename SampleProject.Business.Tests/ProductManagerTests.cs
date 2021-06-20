using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentValidation;
using Moq;
using SampleProject.Business.Abstract;
using SampleProject.Business.Concrete;
using SampleProject.DataAccess.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        private IProductService _productService;
        public ProductManagerTests()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            _productService = new ProductManager(mock.Object);
        }


        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Check_validation()
        {
            _productService.Add(new Product());
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Check_validation_for_zero_price()
        {
            _productService.Add(new Product()
            {
                Name = "Test ürünü",
                Price = 0,
                UnitsInStock = 10
            });
        }

        [TestMethod]
        public void Add_valid_product()
        {
            string name = Guid.NewGuid().ToString();
            var product = _productService.Add(new Product()
            {
                Name = name,
                Price = 10,
                UnitsInStock = 10
            });

            Assert.AreEqual(name, product.Name);
        }
    }
}
