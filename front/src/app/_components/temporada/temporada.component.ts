import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Temporada } from 'src/app/_models/liga';
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

  constructor(private temporadaServicio: TemporadaService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
        this.temporadaId = Number(params.get("id"));
        this.refrescar();
    });
  }

  public refrescar() {
    this.temporadaSubscripcion = this.temporadaServicio.getTemporada(this.temporadaId).subscribe(
        temporada => this.temporada = temporada
    );
  }
}
