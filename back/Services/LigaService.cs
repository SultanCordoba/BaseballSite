using System;
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
            Liga[] fuente = await _contexto.Ligas.ToArrayAsync();
            LigaDto[] respuesta = _mapper.Map<Liga[], LigaDto[]>(fuente);
            return respuesta;
        }

        public async Task<LigaDto> getLiga(int id)
        {
            LigaDto respuesta = null;

            Liga fuente = await _contexto.Ligas.FirstOrDefaultAsync(l => l.Id == id);
            if (fuente != null) {
                respuesta = _mapper.Map<Liga, LigaDto>(fuente);
                Temporadum[] fuenteTemp = await _contexto.Temporada.Where
                    (p => p.LigaId == fuente.Id).ToArrayAsync();

                if (fuenteTemp != null) {
                    respuesta.Temporadas = _mapper.Map<Temporadum[], TemporadaDto[]>(fuenteTemp);
                }
            }

            return respuesta;
        }
    }
}