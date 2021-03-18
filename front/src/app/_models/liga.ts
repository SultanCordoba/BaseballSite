export class Escenario {
    id: number;
    titulo: string;
    tipoEscenarioDesc: string;
    descripcion: string;
    campeon: string;
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
}

export class Liga {
    id: number;
    siglas: string;
    nombre: string;
    activa: boolean;
    temporadas: Temporada[];
}
