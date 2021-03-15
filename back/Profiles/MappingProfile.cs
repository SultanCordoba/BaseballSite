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
                .ForCtorParam("Activa", opt => opt.MapFrom(src => src.Activa))
                ;
            CreateMap<Temporadum, TemporadaDto>() 
                .ForCtorParam("Activa", opt => opt.MapFrom(src => src.Activa))
                ;
            CreateMap<Escenario, EscenarioDto>()
                .ForCtorParam("tipoEsc", opt => opt.MapFrom(src => src.TipoEscenario))
            ;
        }
    }    
}