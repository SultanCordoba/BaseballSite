using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Deporte
    {
        public Deporte()
        {
            Ligas = new HashSet<Liga>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Liga> Ligas { get; set; }
    }
}
