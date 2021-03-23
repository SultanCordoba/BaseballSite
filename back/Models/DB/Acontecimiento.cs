using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Acontecimiento
    {
        public long Id { get; set; }
        public string Fecha { get; set; }
        public string Texto { get; set; }
        public long? TemporadaId { get; set; }

        public virtual Temporadum Temporada { get; set; }
    }
}
