using AutoMapper;
using EC.APPLICATION.Bussiness.ProductFuntions.Queries.ReadQuery;
using EC.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class GetManageProductPagingRequestProfile : Profile
    {
        public GetManageProductPagingRequestProfile()
        {
            CreateMap<GetManageProductPagingRequest, GetAllPagingQueries>();
        }
    }
}
