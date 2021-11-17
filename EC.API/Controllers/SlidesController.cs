using EC.APPLICATION.Business.UntilitiesFuntion.SlidesFuntion.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class SlidesController : MvcControllerBase<SlidesController>
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var slides = await Mediator.Send(new SlideGetAllQueries() { });
            return Ok(slides);
        }
    }
}
