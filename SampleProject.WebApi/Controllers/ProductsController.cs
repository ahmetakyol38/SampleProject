using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApi.Models;

namespace SampleProject.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductViewModel> Get()
        {
            try
            {
                var products = _productService.GetAll();
                return Mapper.Map<List<ProductViewModel>>(products);
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Ürün listeleme esnasında hata oluştu.")
                };

                throw new HttpResponseException(message);
            }
        }

        [HttpPost]
        public ProductViewModel Post(ProductViewModel productViewModel)
        {
            try
            {
                var product = Mapper.Map<Product>(productViewModel);
                Product addedProduct = _productService.Add(product);
                return Mapper.Map<ProductViewModel>(addedProduct);
            }
            catch (ValidationException ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Ürün ekleme esnasında hata oluştu.")
                };

                throw new HttpResponseException(message);
            }
        }
    }
}
