using System;
using System.Collections.Generic;
using System.Text;
using SampleProject.DataAccess.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SampleProjectContext>, IProductDal
    {
    }
}
