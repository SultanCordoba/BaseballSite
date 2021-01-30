using AutoMapper;
using back.Models.DB;
using back.Models.Entities;

namespace back.Models.Services
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Liga, LigaDto>();
        }
    }    
}