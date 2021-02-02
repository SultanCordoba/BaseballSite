using System;

namespace back.Models.Entities
{
    public partial class TemporadaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Activa { get; set; }

        public TemporadaDto(int Activa) {
            this.Activa = Activa > 0;
        }
    }
}