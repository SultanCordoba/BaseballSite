export class SerieAlterna {
    temporada: string;
    escudoTemporada: string;
    equipo1: string;
    escudoEquipo1: string;
    equipo2: string;
    escudoEquipo2: string;
}

export class Decada {
    nombre: string;
    series: SerieAlterna[];
}

export class Standing {
    equipo: string; 
    abrev: string;
    ganados: string;
    perdidos: string;
    empates: string;
    pctje: string;
    juegosDetras: string;
}

export class GrupoDto {
    nombreGrupo: string;
    standings: Standing[];
}

export class EtapaDto {
    nombreEtapa: string;
    grupos: GrupoDto[];
}

export class Escenario {
    id: number;
    titulo: string;
    tipoEscenarioDesc: string;
    descripcion: string;
    campeon: string;
    etapas: EtapaDto[];
}

export class Dupla {
    fuente: string;
    destino: string;
}

export class Movimiento {
    id: number;
    equipoFuente: string;
    equipoDestino: string;
}

export class FullMovimiento {
    claveGrupo: string;
    nombreGrupo: string;
    movimientoDetalle: Movimiento[];
}

export class Lider {
    categoria: string;
    jugador: string;
    orden: number;
    equipo: string;
    rubro: string;
    valor: string;
}

export class LiderTemporada {
    bateo: Lider[];
    pitcheo: Lider[];
    fildeo: Lider[];
}

export class Temporada {
    id: number;
    nombre: string;
    activa: boolean;
    descripcion: string;
    escenarios: Escenario[];
    movimientos: FullMovimiento[];
    lideres: LiderTemporada;
    deporteNombre: string;
}

export class Liga {
    id: number;
    siglas: string;
    nombre: string;
    activa: boolean;
    temporadas: Temporada[];
    deporteNombre: string;
    serieAlternas: Decada[];
}
