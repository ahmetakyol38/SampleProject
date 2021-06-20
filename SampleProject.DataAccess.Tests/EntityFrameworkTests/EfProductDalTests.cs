using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleProject.DataAccess.Abstract;
using SampleProject.DataAccess.Concrete.EntityFramework;
using SampleProject.Entities.Concrete;

namespace SampleProject.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EfProductDalTests
    {
        IProductDal _productDal = new EfProductDal();

        Product AddProduct(string guid)
        {
            Product product = new Product()
            {
                Name = guid,
                Price = 10m,
                UnitsInStock = 10
            };

            return _productDal.Add(product);
        }

        [TestMethod]
        public void Add_new_product()
        {
            string guid = Guid.NewGuid().ToString();
            var addedProduct = AddProduct(guid);

            Assert.AreEqual(guid, addedProduct.Name);
        }

        [TestMethod]
        public void Get_all_products()
        {
            string guid = Guid.NewGuid().ToString();
            AddProduct(guid);

            var productList = _productDal.GetAll();

            Assert.IsTrue(productList.Exists(p=>p.Name == guid));
        }
        
    }
}
