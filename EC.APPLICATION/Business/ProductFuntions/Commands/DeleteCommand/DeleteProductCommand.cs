using EC.APPLICATION.Base.Exceptions;
using EC.APPLICATION.Base.Interfaces;
using EC.CORE.BaseEnumeration;
using EC.ViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Bussiness.ProductFuntions.Commands.DeleteCommand
{
    public class DeleteProductCommand : IRequest<ApiResult<bool>>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResult<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorageService _storageService;

        public DeleteProductCommandHandler(IApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<ApiResult<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(e => e.Id == request.Id && e.DeleteFlag == DeleteFlag.Available.Value);
            if (entity == null)
            {
                return new ApiErrorResult<bool>($"Can not find a product:{request.Id} ");
            }
            entity.DeleteFlag = DeleteFlag.Deleted;
            var images = _context.ProductImages.Where(i => i.ProductId == request.Id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
                _context.ProductImages.Remove(image);
            }
            var productInCategories = _context.ProductInCategories.Where(e => e.ProductId == request.Id);
            foreach(var productInCategory in productInCategories)
            {
                _context.ProductInCategories.Remove(productInCategory);
            }
            _context.Products.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return new ApiSuccessResult<bool>();
        }
    }
}
