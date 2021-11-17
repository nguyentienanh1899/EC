using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.Common
{
    public class ApiSuccessResult<T>:ApiResult<T>
    {
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }
    }
}
