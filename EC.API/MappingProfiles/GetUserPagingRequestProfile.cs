using AutoMapper;
using EC.APPLICATION.Business.UserFuntions.Queries.ReadQuery;
using EC.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class GetUserPagingRequestProfile : Profile
    {
        public GetUserPagingRequestProfile()
        {
            CreateMap<GetUserPagingRequest, GetAllPaging>();
        }
    }
}
