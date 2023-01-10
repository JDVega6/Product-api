using ApiProducts.Data.Dtos;
using ApiProducts.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Data.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //POST
            CreateMap<ProductCreateDto, Products>();

            //PUT
            CreateMap<ProductUpdateDto, Products>();
        }
    }
}
