using System;
using System.Threading.Tasks;
using back.Models.DB;
using back.Models.Entities;

namespace back.Services
{
    public interface ITemporadaService
    {
        public Task<TemporadaDto> getTemporada(int id);
    }
}