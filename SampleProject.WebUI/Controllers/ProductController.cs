using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.WebUI.Models;
using SampleProject.Entities.Concrete;
using SampleProject.WebUI.Filters;

namespace SampleProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ProductCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ExceptionHandler]
        public ActionResult Create(Product product)
        {
            _productService.Add(product);
            return Redirect("/");
        }
    }
}
