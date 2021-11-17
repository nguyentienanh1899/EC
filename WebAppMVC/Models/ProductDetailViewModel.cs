using EC.ViewModel.Categories;
using EC.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class ProductDetailViewModel
    {
        public List<string> Categories { get; set; } = new List<string>();
        public ProductViewModel Product { get; set; }
    }
}
