using System.Collections.ObjectModel;
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
                .IncludeMembers(s => s.Deporte)
                .ForMember(dest => dest.DeporteNombre, opt => opt.MapFrom(src => src.Deporte.Nombre))
                .ForCtorParam("Activa", opt => opt.MapFrom(src => src.Activa))
            ;

            CreateMap<Deporte, LigaDto>();

            CreateMap<Temporadum, TemporadaDto>() 
                .ForCtorParam("Activa", opt => opt.MapFrom(src => src.Activa))
            ;

            CreateMap<Escenario, EscenarioDto>()
                .ForCtorParam("tipoEsc", opt => opt.MapFrom(src => src.TipoEscenario))
            ;

            CreateMap<Lidere, LiderDto>();

            CreateMap<SerieAltDecadum, DecadaDto>()
                .ForMember(d => d.Series, opt => opt.MapFrom(src => src.SerieAlternas))    
            ;
            
            CreateMap<SerieAlterna, SerieAlternaDto>();
        }
    }    
}