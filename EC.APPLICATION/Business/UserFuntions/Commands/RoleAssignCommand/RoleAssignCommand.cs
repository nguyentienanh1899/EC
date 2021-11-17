using EC.CORE.BusinessDomain;
using EC.ViewModel.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.UserFuntions.Commands.RoleAssignCommand
{
    public class RoleAssignCommand : IRequest<ApiResult<bool>>
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
    public class RoleAssignCommandHandler : IRequestHandler<RoleAssignCommand, ApiResult<bool>>
    {
        private readonly UserManager<AppUser> _userManager;
        public RoleAssignCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApiResult<bool>> Handle(RoleAssignCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if(user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = request.Roles.Where(e => e.Selected == false).Select(e => e.Name).ToList();
            foreach( var roleName in removedRoles)
            {
                if(await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user,roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
            var addedRoles = request.Roles.Where(e => e.Selected).Select(e => e.Name).ToList();
            foreach(var roleName in addedRoles)
            {
                if(await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
            return new ApiSuccessResult<bool>();
        }
    }
}
