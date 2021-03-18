import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Lider, Temporada } from 'src/app/_models/liga';
import { TemporadaService } from 'src/app/_services/temporada.service';

@Component({
  selector: 'app-temporada',
  templateUrl: './temporada.component.html',
  styleUrls: ['./temporada.component.scss']
})
export class TemporadaComponent implements OnInit {

    temporadaId: number;
    temporadaSubscripcion: Subscription;
    temporada: Temporada;

    objectKeys = Object.keys;

    displayedColumns: string[] = ['rubro', 'jugador', 'valor'];
    dataSourceBateo: MatTableDataSource<Lider>;
    dataSourcePitcheo: MatTableDataSource<Lider>;

    constructor(private temporadaServicio: TemporadaService,
        private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.route.paramMap.subscribe(params => {
            this.temporadaId = Number(params.get("id"));
            this.refrescar();
        });
    }

    ngOnDestroy(): void {
        if (!!this.temporadaSubscripcion) this.temporadaSubscripcion.unsubscribe();
    }

    public refrescar() {
        this.temporadaSubscripcion = this.temporadaServicio.getTemporada(this.temporadaId).subscribe(
            temporada => {
                this.temporada = temporada;
                this.dataSourceBateo = new MatTableDataSource(temporada.lideres.bateo);
                this.dataSourcePitcheo = new MatTableDataSource(temporada.lideres.pitcheo);
            }
        );
    }
}
