using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Add(Product product);
    }
}
