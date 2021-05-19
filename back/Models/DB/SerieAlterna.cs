using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class SerieAlterna
    {
        public long Id { get; set; }
        public long SerieAltDecadaId { get; set; }
        public string Temporada { get; set; }
        public string EscudoTemporada { get; set; }
        public string Equipo1 { get; set; }
        public string EscudoEquipo1 { get; set; }
        public string Equipo2 { get; set; }
        public string EscudoEquipo2 { get; set; }

        public virtual SerieAltDecadum SerieAltDecada { get; set; }
    }
}
