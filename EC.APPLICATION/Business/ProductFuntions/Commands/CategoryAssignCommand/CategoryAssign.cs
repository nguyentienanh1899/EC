using EC.APPLICATION.Base.Interfaces;
using EC.CORE.BusinessDomain;
using EC.ViewModel.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.ProductFuntions.Commands.CategoryAssignCommand
{
    public class CategoryAssign :IRequest<ApiResult<bool>>
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
    public class CategoryAssignHandler : IRequestHandler<CategoryAssign, ApiResult<bool>>
    {
        private readonly IApplicationDbContext _context;
        public CategoryAssignHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> Handle(CategoryAssign request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if(product == null)
            {
                return new ApiErrorResult<bool>($"Sản phẩm với id {request.Id} không tồn tại");
            }
            foreach(var category in request.Categories)
            {
                var productInCategory = await _context.ProductInCategories.FirstOrDefaultAsync(e => e.CategoryId == int.Parse(category.Id) && e.ProductId == request.Id);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProductInCategories.Remove(productInCategory);
                }
                else if(productInCategory == null && category.Selected == true)
                {
                    await _context.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProductId = request.Id
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
