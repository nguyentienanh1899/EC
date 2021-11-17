using EC.APPLICATION.Base.Interfaces;
using EC.CORE.BaseEnumeration;
using EC.ViewModel.Utilities.Slides;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.UntilitiesFuntion.SlidesFuntion.Queries
{
    public class SlideGetAllQueries : IRequest<List<SlideViewModel>>
    {
    }
    public class SlideGetAllQueriesHandler : IRequestHandler<SlideGetAllQueries, List<SlideViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public SlideGetAllQueriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SlideViewModel>> Handle(SlideGetAllQueries request, CancellationToken cancellationToken)
        {
            var query = _context.Slides.Where(e => e.DeleteFlag == DeleteFlag.Available.Value);
            var slides = await query.OrderBy(x => x.SortOrder)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}
