using EC.CORE.BusinessDomain;
using EC.ViewModel.Common;
using EC.ViewModel.System.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.UserFuntions.Queries.ReadQuery
{
    public class GetAllPaging : GetUserPagingRequest, IRequest<ApiResult<PagedResult<UserViewModel>>>
    {
    }
    public class GetUserQueriesHandler : IRequestHandler<GetAllPaging, ApiResult<PagedResult<UserViewModel>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public GetUserQueriesHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<PagedResult<UserViewModel>>> Handle(GetAllPaging request, CancellationToken cancellationToken)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(e => e.UserName.Contains(request.Keyword) || e.PhoneNumber.Contains(request.Keyword)
                            || e.Email.Contains(request.Keyword) || e.LastName.Contains(request.Keyword)||e.FirstName.Contains(request.Keyword)
                );
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).
                Take(request.PageSize).Select(e => new UserViewModel()
                {
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    UserName = e.UserName,
                    FirstName = e.FirstName,
                    Id = e.Id,
                    LastName = e.LastName
                }).ToListAsync();
            var pagedResult = new PagedResult<UserViewModel>
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
        }
    }
}
