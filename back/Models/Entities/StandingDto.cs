using System;
using System.Collections.Generic;
using back.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace back.Models.Entities
{
    [Keyless]
    public class StandingVista
    {
        public string NombreEtapa { get; set; }
        public string NombreGrupo { get; set; } 
        public string Equipo { get; set; }
        public string Abrev { get; set; }
        public long Ganados { get; set; }
        public long Perdidos { get; set; }
        public long Empates { get; set; }
        public float Pctje { get; set; }
    }

    public class StandingDto
    {
        public string Equipo { get; set; }
        public string Abrev { get; set; }
        public long Ganados { get; set; }
        public long Perdidos { get; set; }
        public long Empates { get; set; }
        public string Grupo { get; set; }
        public string Pctje { get; set; }
        public string JuegosDetras { get; set; }
    }

    public class GrupoStandingDto 
    {
        public string NombreGrupo { get; set; }
        public List<StandingDto> Standings { get; set; } 
    }

    public class EtapaDto 
    {
        public string NombreEtapa { get; set; }
        public List<GrupoStandingDto> Grupos { get; set; }
    } 
}