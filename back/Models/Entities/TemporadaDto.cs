using System;

namespace back.Models.Entities
{
    public class TemporadaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Activa { get; set; }
        public string Descripcion { get; set;}
        public EscenarioDto[] Escenarios { get; set;}

        public TemporadaDto(int Activa) {
            this.Activa = Activa > 0;
        }
    }
}