using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructre.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap(); //cift yonlu donusum yapmak ıcın. veri guncellendiginde veri tabanına dogruda gidiyor

        }
    }
}
