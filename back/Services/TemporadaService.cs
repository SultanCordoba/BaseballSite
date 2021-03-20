using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private string ConstruirQueryStandings(int id) 
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT et.nombre as NombreEtapa, ")
                .Append("  s.grupo as NombreGrupo, s.equipo, s.abrev, ")
                .Append("  s.ganados, s.perdidos, s.empates, ")
                .Append("  (s.ganados * 1.0) / (s.ganados + s.perdidos) as pctje ")
                .Append("FROM standing s INNER JOIN etapa et ")
                .Append("  ON (s.etapa_id = et.id) ")
                .Append("  INNER JOIN escenario esc ")
                .Append("    ON (et.escenario_id = esc.id) ")
                .Append("WHERE esc.id = ").Append(id).Append(" ")
                .Append("ORDER BY esc.id, et.orden, s.grupo, ")
                .Append("  (s.ganados * 1.0) / (s.ganados + s.perdidos) DESC ")
            ;
            return sbQuery.ToString();
        }

        public async Task<TemporadaDto> getTemporada(int id)
        {
            Temporadum temporada = await _contexto.Temporada
                // .Include(t => t.Escenarios)
                // .ThenInclude(e => e.TipoEscenario)
                .FirstOrDefaultAsync(t => t.Id == id);
            TemporadaDto respuesta = _mapper.Map<Temporadum, TemporadaDto>(temporada);    

            Escenario[] escenarios = await _contexto.Escenarios
                .Include(e => e.TipoEscenario)
                .Where(e => e.TemporadaId == id)
                .ToArrayAsync()
            ;

            List<EscenarioDto> escenariosDto = new();
            foreach(Escenario escenario in escenarios) {
                EscenarioDto escenarioDto =_mapper.Map<Escenario, EscenarioDto>(escenario);
                
                // Traer información de standings
                StandingVista[] standings = await _contexto.StandingVistas
                    .FromSqlRaw(ConstruirQueryStandings((int) escenario.Id))
                    .ToArrayAsync()
                ;
                escenarioDto.GeneraStandings(standings);
                escenariosDto.Add(escenarioDto);
            }
            respuesta.Escenarios = escenariosDto.ToArray();

            Movimiento[] movimientos = await _contexto.Movimientos
                .Include(m => m.TipoMovimiento)
                .Where(m => m.TemporadaId == id)
                .OrderBy(m => m.TipoMovimiento.Clave)
                .ThenBy(m => m.EquipoFuente)
                .ToArrayAsync()
            ;
            respuesta.GeneraMovimientos(movimientos);

            // Traer información de líderes
            Lidere[] lideres = await _contexto.Lideres
                .Where(l => l.TemporadaId == id)
                .OrderBy(l => l.Categoria)
                .ThenBy(l => l.Orden)
                .ToArrayAsync();

            if (lideres.Length > 0) {
                LiderDto[] lideresDto = _mapper.Map<Lidere[], LiderDto[]>(lideres);
                respuesta.GeneraLideres(lideresDto);
            }

            return respuesta;
        }
    }
}