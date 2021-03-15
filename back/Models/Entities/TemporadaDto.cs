using System;
using System.Collections.Generic;
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
        public Dictionary<string, DuplaDto[]> Movimientos { get; set;}

        public TemporadaDto(int Activa) {
            this.Activa = Activa > 0;
        }

        public void GeneraMovimientos(Movimiento[] movimientosBD) {
            List<DuplaDto> listaTemp = null;
            Dictionary<string, DuplaDto[]> respuesta = new();

            foreach(Movimiento movimientoBD in movimientosBD) {
                if (respuesta.ContainsKey(movimientoBD.TipoMovimiento.Clave)) {
                    listaTemp = new(respuesta[movimientoBD.TipoMovimiento.Clave]);
                    listaTemp.Add(new DuplaDto(movimientoBD));
                    respuesta[movimientoBD.TipoMovimiento.Clave] = listaTemp.ToArray();
                }
                else {
                    listaTemp = new();
                    listaTemp.Add(new DuplaDto(movimientoBD));
                    respuesta.Add(movimientoBD.TipoMovimiento.Clave, listaTemp.ToArray());
                }
            }

            Movimientos = respuesta;
        }
    }
}