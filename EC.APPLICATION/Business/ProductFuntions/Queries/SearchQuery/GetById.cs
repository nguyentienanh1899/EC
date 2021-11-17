using EC.APPLICATION.Base.Exceptions;
using EC.APPLICATION.Base.Interfaces;
using EC.ViewModel.Common;
using EC.ViewModel.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Bussiness.ProductFuntions.Queries.SearchQuery
{
    public class GetById : IRequest<ApiResult<ProductViewModel>>
    {
        public int Id { get; set; }
    }
    public class GetByIdHandler : IRequestHandler<GetById, ApiResult<ProductViewModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<ProductViewModel>> Handle(GetById request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if(product == null)
            {
                return new ApiErrorResult<ProductViewModel>($"Không tìm thấy sản phẩm có Id:{request.Id} ");
            }
            var categories = await (from c in _context.Categories
                                    join pic in _context.ProductInCategories on c.Id equals pic.CategoryId
                                    where pic.ProductId == request.Id
                                    select c.Name
                                    ).ToListAsync();
            var image = await _context.ProductImages.Where(x => x.ProductId == request.Id && x.IsDefault == true).FirstOrDefaultAsync();
            var productViewModel = new ProductViewModel() { 
                Name = product.Name,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                ThumbnailImage = image != null ? image.ImagePath : "no-image.jpg",
                Categories = categories
                 
            };
            return new ApiSuccessResult<ProductViewModel>(productViewModel);
        }
    }
}
