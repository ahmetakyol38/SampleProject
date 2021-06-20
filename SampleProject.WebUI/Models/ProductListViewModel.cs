using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleProject.Entities.Concrete;

namespace SampleProject.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}