using EC.ViewModel.Categories;
using EC.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.ServiceClient.Interfaces
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<List<CategoryViewModel>>> GetAll();
        Task<CategoryViewModel> GetById(int id);
    }
}
