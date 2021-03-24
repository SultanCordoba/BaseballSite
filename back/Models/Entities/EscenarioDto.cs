using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        [IgnoreMap]
        public EtapaDto[] Etapas { get; set; }

        public EscenarioDto(TipoEscenario tipoEsc) {
            this.TipoEscenarioClave = tipoEsc.Clave;
        }

        public void GeneraStandings(StandingVista[] standings) {
            List<EtapaDto> etapasDto = new();
            StandingVista liderGrupo = null;

            foreach(StandingVista standing in standings) {
                EtapaDto etapa = etapasDto.FirstOrDefault
                    (e => e.NombreEtapa.Equals(standing.NombreEtapa))
                ;

                if (etapa == null) {
                    etapa = new() {
                        NombreEtapa = standing.NombreEtapa,
                        Grupos = new List<GrupoStandingDto>()
                    };
                }
                else {
                    etapasDto.Remove(etapa);
                }

                GrupoStandingDto grupo = etapa.Grupos.FirstOrDefault
                    (g => g.NombreGrupo.Equals(standing.NombreGrupo))
                ;

                if (grupo == null) {
                    grupo = new() {
                        NombreGrupo = standing.NombreGrupo,
                        Standings = new List<StandingDto>()
                    };
                    liderGrupo = standing;
                }
                else {
                    etapa.Grupos.Remove(grupo);
                }

                StandingDto standingDto = new() {
                    Equipo = standing.Equipo,
                    Abrev = standing.Abrev,
                    Ganados = standing.Ganados,
                    Perdidos = standing.Perdidos,
                    Empates = standing.Empates,
                    Pctje = ((standing.Ganados * 1.0) / (standing.Ganados + standing.Perdidos))
                        .ToString("F3")
                };

                // Determinar juegos detras
                standingDto.JuegosDetras = ((((liderGrupo.Ganados - liderGrupo.Perdidos) - (standing.Ganados - standing.Perdidos)) * 1.0) / 2).ToString("F1");

                if (standingDto.JuegosDetras.Equals("0.0")) {
                    standingDto.JuegosDetras = string.Empty;
                }

                grupo.Standings.Add(standingDto);

                etapa.Grupos.Add(grupo);
                etapasDto.Add(etapa);
            }

            Etapas = etapasDto.ToArray();
        }
    }
}