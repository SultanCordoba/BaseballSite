using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Temporadum
    {
        public Temporadum()
        {
            Acontecimientos = new HashSet<Acontecimiento>();
            Escenarios = new HashSet<Escenario>();
            Lideres = new HashSet<Lidere>();
            Movimientos = new HashSet<Movimiento>();
        }

        public long Id { get; set; }
        public long LigaId { get; set; }
        public string Nombre { get; set; }
        public long Activa { get; set; }
        public string FechaInicio { get; set; }
        public string Descripcion { get; set; }

        public virtual Liga Liga { get; set; }
        public virtual ICollection<Acontecimiento> Acontecimientos { get; set; }
        public virtual ICollection<Escenario> Escenarios { get; set; }
        public virtual ICollection<Lidere> Lideres { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
