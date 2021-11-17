using AutoMapper;
using EC.APPLICATION.Bussiness.ProductFuntions.Commands.UpdateCommand;
using EC.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class ProductUpdateRequestProfile : Profile
    {
        public ProductUpdateRequestProfile()
        {
            CreateMap<ProductUpdateRequest, UpdateProductCommand>();
        }
    }
}
