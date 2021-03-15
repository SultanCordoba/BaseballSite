using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class DuplaDto
    {
        public string Fuente { get; set; }
        public string Destino { get; set; }

        public DuplaDto(Movimiento movimiento) {
            Fuente = movimiento.EquipoFuente;
            Destino = movimiento.EquipoDestino;
        }
    }
}