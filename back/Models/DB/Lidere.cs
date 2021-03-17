using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Lidere
    {
        public long Id { get; set; }
        public long TemporadaId { get; set; }
        public string Categoria { get; set; }
        public string Rubro { get; set; }
        public string Jugador { get; set; }
        public string Equipo { get; set; }
        public double Valor { get; set; }

        public virtual Temporadum Temporada { get; set; }
    }
}
