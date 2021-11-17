using EC.APPLICATION.Base.Interfaces;
using EC.CORE.BaseEnumeration;
using EC.ViewModel.Categories;
using EC.ViewModel.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.CategoriesFuntions.Queries
{
    public class GetAllCategories : IRequest<ApiResult<List<CategoryViewModel>>>
    {
        
    }
    public  class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, ApiResult<List<CategoryViewModel>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCategoriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<List<CategoryViewModel>>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var query = _context.Categories.Where(e => e.DeleteFlag == DeleteFlag.Available.Value);
            var queryViewModel = await query.Select(e => new CategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                ParentId = e.ParentId
            }).ToListAsync();
            return new ApiSuccessResult<List<CategoryViewModel>>(queryViewModel);
        }
    }
}
