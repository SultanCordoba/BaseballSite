using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using back.Models.DB;

namespace back.Models.Entities
{
    public class DecadaDto
    {
        public string Decada { get; set; }
        public SerieAlternaDto[] Series { get; set; }
    }

    public class SerieAlternaDto
    {
        public long Id { get; set; }
        public string Temporada { get; set; }
        public string EscudoTemporada { get; set; }
        public string Equipo1 { get; set; }
        public string EscudoEquipo1 { get; set; }
        public string Equipo2 { get; set; }
        public string EscudoEquipo2 { get; set; }
    }
}