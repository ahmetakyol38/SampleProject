using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProject.WebApi.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }
}