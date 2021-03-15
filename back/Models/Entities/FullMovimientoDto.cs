using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class FullMovimientoDto
    {
        public string ClaveGrupo { get; set; }
        public string NombreGrupo { get; set; }
        public MovimientoDto[] MovimientoDetalle { get; set; }
    }
}