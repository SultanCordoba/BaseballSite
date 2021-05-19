using System;

namespace back.Models.Entities
{
    public class LigaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public Boolean Activa { get; set; }
        public TemporadaDto[] Temporadas { get; set; }
        public DecadaDto[] SerieAlternas { get; set; }
        public string DeporteNombre { get; set; }

        public LigaDto(int Activa) {
            this.Activa = Activa > 0;
        }
    }
}