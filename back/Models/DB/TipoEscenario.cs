using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class TipoEscenario
    {
        public TipoEscenario()
        {
            Escenarios = new HashSet<Escenario>();
        }

        public long Id { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Escenario> Escenarios { get; set; }
    }
}
