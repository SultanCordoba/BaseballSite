using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using back.Models.DB;

namespace back.Models.Entities
{
    public class TemporadaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Boolean Activa { get; set; }
        public string Descripcion { get; set;}
        public EscenarioDto[] Escenarios { get; set;}
        public FullMovimientoDto[] Movimientos { get; set;}
        
        [IgnoreMap]
        public LiderTemporadaDto Lideres { get; set;}

        public TemporadaDto(int Activa) {
            this.Activa = Activa > 0;
        }

        public void GeneraMovimientos(Movimiento[] movimientosBD) {
            List<FullMovimientoDto> movimientos = new();

            foreach(Movimiento movimientoBD in movimientosBD) {
                FullMovimientoDto temporal = movimientos
                    .FirstOrDefault(fm => fm.ClaveGrupo.Equals(movimientoBD.TipoMovimiento.Clave))
                ;
                List<MovimientoDto> detalles = new();

                if (temporal == null) {
                    temporal = new FullMovimientoDto() {
                        ClaveGrupo = movimientoBD.TipoMovimiento.Clave,
                        NombreGrupo = movimientoBD.TipoMovimiento.Nombre,
                    };
                }
                else {
                    movimientos.Remove(temporal);
                    detalles = new(temporal.MovimientoDetalle);
                }
                
                detalles.Add(new MovimientoDto(){
                    TipoMovimientoClave = movimientoBD.TipoMovimiento.Clave,
                    EquipoFuente = movimientoBD.EquipoFuente,
                    EquipoDestino = movimientoBD.EquipoDestino
                });

                temporal.MovimientoDetalle = detalles.ToArray();
                movimientos.Add(temporal);
            }

            Movimientos = movimientos.ToArray();           
        }

        public void GeneraLideres(LiderDto[] lideres) {
            Lideres = new();
            List<LiderDto> bateo = new();
            List<LiderDto> pitcheo = new();

            foreach(LiderDto lider in lideres) {
                if (lider.Categoria.Equals("Bateo")) {
                    bateo.Add(lider);
                }

                if (lider.Categoria.Equals("Pitcheo")) {
                    pitcheo.Add(lider);
                }
            }

            Lideres.Bateo = bateo.ToArray();
            Lideres.Pitcheo = pitcheo.ToArray();
        }
    }
}