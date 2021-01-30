import { Component, OnInit } from '@angular/core';
import { Liga } from 'src/app/_models/liga';
import { LigaService } from 'src/app/_services/liga.service';

@Component({
  selector: 'app-ligas',
  templateUrl: './ligas.component.html',
  styleUrls: ['./ligas.component.scss']
})
export class LigasComponent implements OnInit {

    ligas: Liga[];

  constructor(private ligaService: LigaService) { }

  ngOnInit(): void {
    this.ligaService.listaLigas().subscribe(
        ligas => this.ligas = ligas
    );
  }

}
