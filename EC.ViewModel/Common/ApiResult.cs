using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Common
{
    public class ApiResult<T> 
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
    }
}
