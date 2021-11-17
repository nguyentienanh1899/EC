using EC.CORE.BusinessDomain;
using EC.ViewModel.Common;
using EC.ViewModel.System.Role;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.RoleFuntions.Queries
{
    public class RoleGetAll : IRequest<ApiResult<List<RoleViewModel>>>
    {

    }
    public class RoleGetAllHandler : IRequestHandler<RoleGetAll, ApiResult<List<RoleViewModel>>>
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleGetAllHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ApiResult<List<RoleViewModel>>> Handle(RoleGetAll request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.Select(e => new RoleViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description
            }).ToListAsync();
            return new ApiSuccessResult<List<RoleViewModel>>(roles);
        }
    }
}
