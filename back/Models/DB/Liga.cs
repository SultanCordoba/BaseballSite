using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Liga
    {
        public Liga()
        {
            SerieAltDecada = new HashSet<SerieAltDecadum>();
            Temporada = new HashSet<Temporadum>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public long? Activa { get; set; }
        public long DeporteId { get; set; }

        public virtual Deporte Deporte { get; set; }
        public virtual ICollection<SerieAltDecadum> SerieAltDecada { get; set; }
        public virtual ICollection<Temporadum> Temporada { get; set; }
    }
}
