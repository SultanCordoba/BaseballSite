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
    }
}