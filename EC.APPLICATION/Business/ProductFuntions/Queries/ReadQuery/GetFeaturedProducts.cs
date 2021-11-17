using EC.APPLICATION.Base.Interfaces;
using EC.ViewModel.Products;
using MediatR;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EC.CORE.BaseEnumeration;
using Microsoft.EntityFrameworkCore;

namespace EC.APPLICATION.Business.ProductFuntions.Queries.ReadQuery
{
    public class GetFeaturedProducts : IRequest<List<ProductViewModel>>
    {
        public int take { get; set; }
    }
    public class GetFeaturedProductsHandler : IRequestHandler<GetFeaturedProducts, List<ProductViewModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetFeaturedProductsHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductViewModel>> Handle(GetFeaturedProducts request, CancellationToken cancellationToken)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.Id equals pi.ProductId
                        into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where p.DeleteFlag == DeleteFlag.Available.Value && p.IsFeatured == true
                        && (pi == null || pi.IsDefault == true)
                        select new { p, pic, pi };
            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(request.take)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            return data;
        }
    }
}
