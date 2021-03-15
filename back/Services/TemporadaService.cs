using System.Linq;
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
            Temporadum temporada = await _contexto.Temporada
                .Include(t => t.Escenarios)
                .ThenInclude(e => e.TipoEscenario)
                .FirstOrDefaultAsync(t => t.Id == id);
            TemporadaDto respuesta = _mapper.Map<Temporadum, TemporadaDto>(temporada);
            /* Escenario[] escenarios = await _contexto.Escenarios
                .Where(e => e.TemporadaId == id)
                .ToArrayAsync()
            ;

            if (escenarios.Length > 0) {
                respuesta.Escenarios = _mapper.Map<Escenario[], EscenarioDto[]>(escenarios);
            }  */         

            return respuesta;
        }
    }
}