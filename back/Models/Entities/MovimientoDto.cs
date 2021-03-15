using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class MovimientoDto
    {
        public long Id { get; set; }
        public string TipoMovimientoClave { get; set; }
        public string EquipoFuente { get; set; }
        public string EquipoDestino { get; set; }

        public MovimientoDto(TipoMovimiento tipoMov) {
            this.TipoMovimientoClave = tipoMov.Clave;
        }
    }
}