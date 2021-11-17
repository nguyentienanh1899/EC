using AutoMapper;
using EC.APPLICATION.Bussiness.ProductFuntions.Commands.CreateCommand;
using EC.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.API.MappingProfiles
{
    public class ProductCreateRequestProfile : Profile
    {
        public ProductCreateRequestProfile()
        {
            CreateMap<ProductCreateRequest, CreateProductCommand>();
        }
    }
}
