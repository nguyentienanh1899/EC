using System.Linq;
using EC.APPLICATION.Base.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EC.CORE.BaseEnumeration;
using Microsoft.EntityFrameworkCore;
using EC.ViewModel.Products;
using EC.ViewModel.Common;

namespace EC.APPLICATION.Bussiness.ProductFuntions.Queries.ReadQuery
{

    public class  GetAllPagingQueries : GetManageProductPagingRequest,IRequest<ApiResult<PagedResult<ProductViewModel>>>
    {
        
    }
    public class GetAllPagingHandler : IRequestHandler<GetAllPagingQueries, ApiResult<PagedResult<ProductViewModel>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPagingHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> Handle(GetAllPagingQueries request, CancellationToken cancellationToken)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        into ppic from pic in ppic.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.Id equals pi.ProductId
                        into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where p.DeleteFlag == DeleteFlag.Available.Value && pi.IsDefault==true
                        select new { p, pic,pi };
            /* var query = from p in _context.Products
                         where p.DeleteFlag == DeleteFlag.Available.Value
                         select new { p };*/
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Name.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new ProductViewModel()
                {
                   Id = e.p.Id,
                   Name = e.p.Name,
                   OriginalPrice =e.p.OriginalPrice,
                   Price = e.p.Price,
                   Stock = e.p.Stock,
                   ViewCount = e.p.ViewCount,
                   ThumbnailImage= e.pi.ImagePath
                }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }
    }
}
