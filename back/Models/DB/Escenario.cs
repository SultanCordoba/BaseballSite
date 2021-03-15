using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Escenario
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public long TemporadaId { get; set; }
        public long TipoEscenarioId { get; set; }
        public string Descripcion { get; set; }
        public string Campeon { get; set; }

        public virtual Temporadum Temporada { get; set; }
        public virtual TipoEscenario TipoEscenario { get; set; }
    }
}
