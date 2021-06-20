using System;
using System.Collections.Generic;
using System.Text;
using SampleProject.Entities.Concrete;

namespace SampleProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
