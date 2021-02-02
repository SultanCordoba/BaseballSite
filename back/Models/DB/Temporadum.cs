using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Temporadum
    {
        public long Id { get; set; }
        public long LigaId { get; set; }
        public string Nombre { get; set; }
        public long Activa { get; set; }
        public string FechaInicio { get; set; }

        public virtual Liga Liga { get; set; }
    }
}
