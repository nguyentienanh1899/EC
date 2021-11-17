using EC.APPLICATION.Base.Exceptions;
using EC.APPLICATION.Base.Interfaces;
using EC.CORE.BaseEnumeration;
using EC.CORE.BusinessDomain;
using EC.CORE.Constants;
using EC.ViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Bussiness.ProductFuntions.Commands.UpdateCommand
{
    public class UpdateProductCommand : IRequest<ApiResult<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public IFormFile ThumbnailImage { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResult<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorageService _storageService;
        public UpdateProductCommandHandler(IApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + ApplicationConstant.USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        public async Task<ApiResult<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(e => e.Id == request.Id && e.DeleteFlag == DeleteFlag.Available.Value);
            if (entity == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy sản phẩm với Id: {request.Id}");
            }
            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.OriginalPrice = request.OriginalPrice;
            entity.Stock = request.Stock;

            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                     await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
    }
