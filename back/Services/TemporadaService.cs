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

            Movimiento[] movimientos = await _contexto.Movimientos
                .Include(m => m.TipoMovimiento)
                .Where(m => m.TemporadaId == id)
                .OrderBy(m => m.TipoMovimiento.Clave)
                .ThenBy(m => m.EquipoFuente)
                .ToArrayAsync()
            ;
            respuesta.GeneraMovimientos(movimientos);

            Lidere[] lideres = await _contexto.Lideres
                .Where(l => l.TemporadaId == id)
                .OrderBy(l => l.Categoria)
                .ThenBy(l => l.Rubro)
                .ThenBy(l => l.Jugador)
                .ToArrayAsync();

            if (lideres.Length > 0) {
                LiderDto[] lideresDto = _mapper.Map<Lidere[], LiderDto[]>(lideres);
                respuesta.GeneraLideres(lideresDto);
            }

            return respuesta;
        }
    }
}