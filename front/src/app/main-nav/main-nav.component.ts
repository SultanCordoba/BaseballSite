import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Liga } from '../_models/liga';
import { LigaService } from '../_services/liga.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    ligas: Liga[];

  constructor(private breakpointObserver: BreakpointObserver,
    private ligaService: LigaService) {}

  ngOnInit(): void {
    this.ligaService.listaLigas().subscribe(
        ligas => this.ligas = ligas
    );
  }

}
