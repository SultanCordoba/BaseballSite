import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Liga } from 'src/app/_models/liga';
import { LigaService } from 'src/app/_services/liga.service';

@Component({
  selector: 'app-ligas',
  templateUrl: './ligas.component.html',
  styleUrls: ['./ligas.component.scss']
})
export class LigasComponent implements OnInit {

    liga: Liga
    ligaId: number;

  constructor(private ligaService: LigaService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
        this.ligaId = Number(params.get("id"));
        this.refrescar();
    });
  }

  private refrescar() {
      this.ligaService.getLiga(this.ligaId).subscribe(
          liga => this.liga = liga
      );
  }
}
