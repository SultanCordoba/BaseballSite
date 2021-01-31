using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models.DB;
using back.Models.Entities;
using back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LigaController : ControllerBase
    {
        private readonly ILogger<LigaController> _logger;
        private readonly ILigaService _ligaService;

        public LigaController(ILogger<LigaController> logger,
            ILigaService ligaService)
        {
            _logger = logger;
            _ligaService = ligaService;
        }

        [HttpGet]
        public async Task<LigaDto[]> getAll() {
            return await _ligaService.getAll();
        }

        [HttpGet("{id}")]
        public async Task<LigaDto> GetLiga(int id) {
            return await _ligaService.getLiga(id);
        }
    }
}