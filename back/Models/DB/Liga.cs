using System;
using System.Collections.Generic;

#nullable disable

namespace back.Models.DB
{
    public partial class Liga
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public long? Activa { get; set; }
    }
}
