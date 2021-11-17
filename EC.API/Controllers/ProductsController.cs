
using AutoMapper;
using EC.APPLICATION.Business.ProductFuntions.Commands.CategoryAssignCommand;
using EC.APPLICATION.Business.ProductFuntions.Queries.ReadQuery;
using EC.APPLICATION.Bussiness.ProductFuntions.Commands.CreateCommand;
using EC.APPLICATION.Bussiness.ProductFuntions.Commands.DeleteCommand;
using EC.APPLICATION.Bussiness.ProductFuntions.Commands.UpdateCommand;
using EC.APPLICATION.Bussiness.ProductFuntions.Queries.ReadQuery;
using EC.APPLICATION.Bussiness.ProductFuntions.Queries.SearchQuery;
using EC.ViewModel.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : MvcControllerBase<ProductsController>
    {
        [HttpGet("{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await Mediator.Send(new GetById() { 
                Id = productId
            });
            return Ok(product);
        }
        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await Mediator.Send(Mapper.Map<GetManageProductPagingRequest, GetAllPagingQueries>(request));
            return Ok(products);
        }
        [HttpGet("featured/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(int take)
        {
            var products = await Mediator.Send(new GetFeaturedProducts()
            {
                take = take
            });
            return Ok(products);
        }
        [HttpGet("latest/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(int take, string languageId)
        {
            var products = await Mediator.Send(new GetLatestProducts()
            {
                take = take
            });
            return Ok(products);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]//nhận về 1 dữ liệu dạng form-data
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await Mediator.Send(Mapper.Map<ProductCreateRequest, CreateProductCommand>(request));
            if (productId == 0)
                return BadRequest();

            var product = await Mediator.Send(new GetById() {Id = productId } );
            return Ok(product);
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await Mediator.Send(new DeleteProductCommand() {Id = productId });
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
            var result = await Mediator.Send(Mapper.Map<ProductUpdateRequest, UpdateProductCommand>(request));
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id,[FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await Mediator.Send(new CategoryAssign()
            {
                Id = id,
                Categories = request.Categories
            });
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
