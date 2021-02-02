using System.Threading.Tasks;
using AutoMapper;
using back.Models.DB;
using back.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Services
{
    public class TemporadaService : ITemporadaService
    {
        private readonly BaseballDbContext _contexto;
        private readonly IMapper _mapper;
        
        public TemporadaService(BaseballDbContext contexto,
            IMapper mapper) {
            this._contexto = contexto;
            this._mapper = mapper;
        }

        public async Task<TemporadaDto> getTemporada(int id)
        {
            TemporadaDto respuesta;
            Temporadum temporada = await _contexto.Temporada.FirstOrDefaultAsync(t => t.Id == id);
            respuesta = _mapper.Map<Temporadum, TemporadaDto>(temporada);

            return respuesta;
        }
    }
}