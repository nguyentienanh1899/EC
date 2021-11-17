
using EC.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? CategoryId { get; set; }
    }
}
