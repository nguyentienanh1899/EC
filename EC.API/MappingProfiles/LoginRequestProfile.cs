using AutoMapper;
using EC.APPLICATION.Business.AuthenticationFuntions;
using EC.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class LoginRequestProfile : Profile
    {
        public LoginRequestProfile()
        {
            CreateMap<LoginRequest, AuthencateQueries>();
        }
    }
}
