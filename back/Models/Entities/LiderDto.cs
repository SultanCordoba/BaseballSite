using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class LiderDto
    {
        public string Categoria { get; set; }
        public string Jugador { get; set; }
        public int Orden { get; set; }
        public string Equipo { get; set; }
        public string Rubro { get; set; }
        public string Valor { get; set; }
    }
}