using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Standing
    {
        public long Id { get; set; }
        public long EtapaId { get; set; }
        public string Equipo { get; set; }
        public string Abrev { get; set; }
        public long Ganados { get; set; }
        public long Perdidos { get; set; }
        public long? Empates { get; set; }
        public string Grupo { get; set; }

        public virtual Etapa Etapa { get; set; }
    }
}
