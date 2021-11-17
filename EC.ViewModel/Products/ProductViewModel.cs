using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Products
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public decimal OriginalPrice { set; get; }
        public decimal Price { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public string ThumbnailImage { get; set; }
        public bool? IsFeatured { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
