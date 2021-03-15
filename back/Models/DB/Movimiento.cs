using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Movimiento
    {
        public long Id { get; set; }
        public long TemporadaId { get; set; }
        public long TipoMovimientoId { get; set; }
        public string EquipoFuente { get; set; }
        public string EquipoDestino { get; set; }

        public virtual Temporadum Temporada { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
    }
}
