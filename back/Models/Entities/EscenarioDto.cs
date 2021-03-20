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
                }
                else {
                    etapa.Grupos.Remove(grupo);
                }

                grupo.Standings.Add(
                    new StandingDto() {
                        Equipo = standing.Equipo,
                        Abrev = standing.Abrev,
                        Ganados = standing.Ganados,
                        Perdidos = standing.Perdidos,
                        Empates = standing.Empates
                    }
                );

                etapa.Grupos.Add(grupo);
                etapasDto.Add(etapa);
            }

            Etapas = etapasDto.ToArray();
        }
    }
}