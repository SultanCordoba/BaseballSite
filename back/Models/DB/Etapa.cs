using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Etapa
    {
        public Etapa()
        {
            Standings = new HashSet<Standing>();
        }

        public long Id { get; set; }
        public long EscenarioId { get; set; }
        public string Nombre { get; set; }
        public long Orden { get; set; }
        public string TipoEtapa { get; set; }

        public virtual Escenario Escenario { get; set; }
        public virtual ICollection<Standing> Standings { get; set; }
    }
}
