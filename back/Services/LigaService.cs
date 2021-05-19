using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.Models.DB;
using back.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Services
{
    public class LigaService : ILigaService
    {
        private readonly BaseballDbContext _contexto;
        private readonly IMapper _mapper;

        public LigaService(BaseballDbContext contexto,
            IMapper mapper) {
            this._contexto = contexto;
            this._mapper = mapper;
        }

        public async Task<LigaDto[]> getAll()
        {
            Liga[] fuente = await _contexto.Ligas
                .Include(l => l.Deporte)
                .ToArrayAsync();
            LigaDto[] respuesta = _mapper.Map<Liga[], LigaDto[]>(fuente);
            return respuesta;
        }

        public async Task<LigaDto> getLiga(int id)
        {
            LigaDto respuesta = null;

            Liga fuente = await _contexto.Ligas
                .Include(l => l.Deporte)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (fuente != null) {
                respuesta = _mapper.Map<Liga, LigaDto>(fuente);
                Temporadum[] fuenteTemp = await _contexto.Temporada
                    .Where(p => p.LigaId == fuente.Id)
                    .OrderByDescending(t => t.FechaInicio)
                    .ToArrayAsync();

                if (fuenteTemp != null) {
                    respuesta.Temporadas = _mapper.Map<Temporadum[], TemporadaDto[]>(fuenteTemp);
                }

                SerieAltDecadum[] decadas = await _contexto.SerieAltDecada
                    .Include(p => p.SerieAlternas)
                    .Where(p => p.LigaId == fuente.Id)
                    .OrderByDescending(p => p.Decada)
                    .ToArrayAsync()
                ;

                // HashSet<DecadaDto> decadasDto = new();
                // foreach(SerieAltDecadum decada in decadas) {
                //     DecadaDto decadaDtoNew = _mapper.Map<SerieAltDecadum, DecadaDto>(decada);
                //     decadaDtoNew.Series = _mapper.Map<SerieAlterna[], SerieAlternaDto[]>(decada.SerieAlternas.ToArray());
                //     decadasDto.Add(decadaDtoNew);
                // }

                // if (decadasDto.Count > 0) {
                //     respuesta.SerieAlternas = decadasDto.ToArray();
                // }

                if (decadas.Length > 0) {
                    respuesta.SerieAlternas = _mapper.Map<SerieAltDecadum[], DecadaDto[]>(decadas);
                }
            }

            return respuesta;
        }
    }
}