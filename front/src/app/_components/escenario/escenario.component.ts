import { Component, Input, OnInit } from '@angular/core';
import { Escenario } from 'src/app/_models/liga';

@Component({
  selector: 'app-escenario',
  templateUrl: './escenario.component.html',
  styleUrls: ['./escenario.component.scss']
})
export class EscenarioComponent implements OnInit {

    public simulacion: Escenario;

    @Input() set escenario(value: any) {
        this.simulacion = value;
    }

    constructor() { }

    ngOnInit(): void {
    }
}
