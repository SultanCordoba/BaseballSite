import { Component, Input, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { GrupoDto, Standing } from 'src/app/_models/liga';

@Component({
  selector: 'app-escenario-grupo',
  templateUrl: './escenario-grupo.component.html',
  styleUrls: ['./escenario-grupo.component.scss']
})
export class EscenarioGrupoComponent implements OnInit {

    public grupoEtapa: GrupoDto;

    @Input() set grupo(value: any) {
        this.grupoEtapa = value;
    }

    displayedColumns: string[] = ['equipo', 'ganados', 'perdidos'];
    dataSource: MatTableDataSource<Standing>;

    constructor() { }

    ngOnInit(): void {
        console.warn(this.grupoEtapa);
        this.dataSource = new MatTableDataSource(this.grupoEtapa.standings);
    }

}
