using EC.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
