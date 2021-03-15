using System.Threading.Tasks;
using back.Models.Entities;
using back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly ILogger<TemporadaController> _logger;
        private readonly ITemporadaService _temporadaService;

        public TemporadaController(ILogger<TemporadaController> logger,
            ITemporadaService temporadaService)
        {
            _logger = logger;
            _temporadaService = temporadaService;
        }

        [HttpGet("{id}")]
        public async Task<TemporadaDto> GetTemporada(int id) {
            return await _temporadaService.getTemporada(id);
        }
    }
}