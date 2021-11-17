using AutoMapper;
using EC.APPLICATION.Business.UserFuntions.Commands.RegisterCommand;
using EC.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class RegisterRequestProfile : Profile
    {
        public RegisterRequestProfile()
        {
            CreateMap<RegisterRequest, RegisterCommand>();
        }
    }
}
