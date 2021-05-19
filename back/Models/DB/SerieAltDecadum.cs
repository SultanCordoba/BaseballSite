using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class SerieAltDecadum
    {
        public SerieAltDecadum()
        {
            SerieAlternas = new HashSet<SerieAlterna>();
        }

        public long Id { get; set; }
        public string Decada { get; set; }
        public long LigaId { get; set; }

        public virtual Liga Liga { get; set; }
        public virtual ICollection<SerieAlterna> SerieAlternas { get; set; }
    }
}
