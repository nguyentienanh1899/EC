using EC.APPLICATION.Business.AuthenticationFuntions;
using EC.APPLICATION.Business.UserFuntions.Commands.DeleteCommand;
using EC.APPLICATION.Business.UserFuntions.Commands.RegisterCommand;
using EC.APPLICATION.Business.UserFuntions.Commands.RoleAssignCommand;
using EC.APPLICATION.Business.UserFuntions.Commands.UpdateCommand;
using EC.APPLICATION.Business.UserFuntions.Queries.ReadQuery;
using EC.APPLICATION.Business.UserFuntions.Queries.SearchQuery;
using EC.ViewModel.System.User;
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
    public class UsersController : MvcControllerBase<UsersController>
    {
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await Mediator.Send(Mapper.Map<LoginRequest, AuthencateQueries>(request));
            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await Mediator.Send(Mapper.Map<RegisterRequest, RegisterCommand>(request));
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userCommand = new UpdateUserCommand()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dob = request.Dob,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber

            };
            var result = await Mediator.Send(userCommand);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword= (FromQuery)
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var users = await Mediator.Send(Mapper.Map<GetUserPagingRequest, GetAllPaging>(request));
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await Mediator.Send(new GetById() {Id = id});
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok(result);
        }
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await Mediator.Send(new RoleAssignCommand()
            {
                Id = id,
                Roles = request.Roles
            });
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
