using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Business.Abstract;
using SampleProject.Business.Validation.FluentValidation;
using SampleProject.Business.Validation.FluentValidation.Rules;
using SampleProject.DataAccess.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product Add(Product product)
        {
            Validator.Validate(new ProductValidator(), product);

            _productDal.Add(product);

            return product;
        }
    }
}
