using AutoMapper;
using back.Models.DB;
using back.Models.Entities;

namespace back.Profiles
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Liga, LigaDto>()
                .ForCtorParam("Activa", opt => opt.MapFrom(src => src.Activa));
        }
    }    
}