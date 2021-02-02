export class Temporada {
    id: number;
    nombre: string;
    activa: boolean;
}

export class Liga {
    id: number;
    siglas: string;
    nombre: string;
    activa: boolean;
    temporadas: Temporada[];
}
