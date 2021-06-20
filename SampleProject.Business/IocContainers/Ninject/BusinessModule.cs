using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SampleProject.Business.Abstract;
using SampleProject.Business.Concrete;
using SampleProject.DataAccess.Abstract;
using SampleProject.DataAccess.Concrete.EntityFramework;

namespace SampleProject.Business.IocContainers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
        }
    }
}
