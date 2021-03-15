using System;

namespace back.Models.Entities
{
    public class EscenarioDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string TipoEscenarioDesc { get; set; }
        public string Descripcion { get; set; }
        public string Campeon { get; set; }
    }
}