using EC.APPLICATION.Business.RoleFuntions.Queries;
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
    public class RolesController : MvcControllerBase<RolesController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await Mediator.Send(new RoleGetAll());
            return Ok(roles);
        }
    }
}
