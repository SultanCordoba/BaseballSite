import { Component, Input, OnInit } from '@angular/core';
import { SerieAlterna } from 'src/app/_models/liga';

@Component({
  selector: 'app-serie-alterna',
  templateUrl: './serie-alterna.component.html',
  styleUrls: ['./serie-alterna.component.scss']
})
export class SerieAlternaComponent implements OnInit {

    displayedColumns: string[] = ['temporada', 'equipo1', 'equipo2'];

  constructor() { }

    public serieAlternas: SerieAlterna[];
    @Input() set series(value: any) {
        this.serieAlternas = value;
        console.log(value);
    }

  ngOnInit(): void {
  }

}
