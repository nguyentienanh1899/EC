using EC.APPLICATION.Business.CategoriesFuntions.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MvcControllerBase<CategoriesController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await Mediator.Send(new GetAllCategories() { });
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await Mediator.Send(new GetByIdCategory() {Id = id });
            return Ok(category);
        }

    }
}
