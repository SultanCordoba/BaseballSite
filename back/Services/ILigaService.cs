using System;
using System.Threading.Tasks;
using back.Models.DB;
using back.Models.Entities;

namespace back.Services
{
    public interface ILigaService
    {
        public Task<LigaDto[]> getAll();
    }
}