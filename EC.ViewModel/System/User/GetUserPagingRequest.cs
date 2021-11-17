using EC.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.System.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
