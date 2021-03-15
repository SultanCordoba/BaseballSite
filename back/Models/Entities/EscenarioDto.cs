using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class EscenarioDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string TipoEscenarioClave { get; set; }
        public string Descripcion { get; set; }
        public string Campeon { get; set; }

        public EscenarioDto(TipoEscenario tipoEsc) {
            this.TipoEscenarioClave = tipoEsc.Clave;
        }
    }
}