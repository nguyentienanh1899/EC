using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
