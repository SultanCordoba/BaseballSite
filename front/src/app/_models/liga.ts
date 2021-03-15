export class Escenario {
    id: number;
    titulo: string;
    tipoEscenarioDesc: string;
    descripcion: string;
    campeon: string;
}

export class Temporada {
    id: number;
    nombre: string;
    activa: boolean;
    descripcion: string;
    escenarios: Escenario[];
}

export class Liga {
    id: number;
    siglas: string;
    nombre: string;
    activa: boolean;
    temporadas: Temporada[];
}
