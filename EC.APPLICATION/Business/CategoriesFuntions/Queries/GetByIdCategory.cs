using EC.APPLICATION.Base.Interfaces;
using EC.ViewModel.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EC.APPLICATION.Business.CategoriesFuntions.Queries
{
    public class GetByIdCategory :IRequest<CategoryViewModel>
    {
        public int Id { get; set; }
    }
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategory, CategoryViewModel>
    {

        private readonly IApplicationDbContext _context;

        public GetByIdCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryViewModel> Handle(GetByIdCategory request, CancellationToken cancellationToken)
        {
            var query =  _context.Categories.Where(e => e.Id == request.Id);
            var result = await query.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId
            }).FirstOrDefaultAsync();
            return result;
        }
    }
}
