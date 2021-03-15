
export class Temporada {
    id: number;
    nombre: string;
    activa: boolean;
    descripcion: string;
}

export class Liga {
    id: number;
    siglas: string;
    nombre: string;
    activa: boolean;
    temporadas: Temporada[];
}
