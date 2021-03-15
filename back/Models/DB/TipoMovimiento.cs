using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public long Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
