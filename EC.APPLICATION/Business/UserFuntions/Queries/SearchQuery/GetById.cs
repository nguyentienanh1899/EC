using EC.CORE.BusinessDomain;
using EC.ViewModel.Common;
using EC.ViewModel.System.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EC.APPLICATION.Business.UserFuntions.Queries.SearchQuery
{
    public class GetById : IRequest<ApiResult<UserViewModel>>
    {
        public Guid Id { get; set; }
    }
    public class GetByIdHandler : IRequestHandler<GetById, ApiResult<UserViewModel>>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetByIdHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApiResult<UserViewModel>> Handle(GetById request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = new UserViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Dob = user.Dob,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                Roles = roles
            };
            return new ApiSuccessResult<UserViewModel>(userVm);
        }
    }
}
