using EC.ViewModel.Common;
using EC.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.ServiceClient.Interfaces
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductViewModel>>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ApiResult<ProductViewModel>> GetById(int id);
        Task<ApiResult<bool>> UpdateProduct(int id, ProductUpdateRequest request);
        Task<List<ProductViewModel>> GetFeaturedProducts(int take);
        Task<ApiResult<bool>> Delete(int id);
        Task<List<ProductViewModel>> GetLatestProducts(int take);

    }
}
