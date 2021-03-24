import { Component, Input, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable, Subscription } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Liga } from '../_models/liga';
import { LigaService } from '../_services/liga.service';
import { CompartirService } from '../_services/compartir.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent implements OnInit {

//   isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
//     .pipe(
//       map(result => result.matches),
//       shareReplay()
//     );

    ligas: Liga[];

    public titulo: string;
    tituloSubscription: Subscription;
    ligasSubscription: Subscription;

  constructor(//private breakpointObserver: BreakpointObserver,
    private ligaService: LigaService,
    private compartirService: CompartirService) {
        this.tituloSubscription = compartirService.tituloNav$.subscribe(
            tituloNav => {
                this.titulo = tituloNav;
            }
        );
    }

  ngOnInit(): void {
      this.ligasSubscription = 
        this.ligaService.listaLigas().subscribe(
            ligas => this.ligas = ligas
        );
  }

  ngOnDestroy(): void {
      if (this.tituloSubscription) this.tituloSubscription.unsubscribe();
      if (this.ligasSubscription) this.ligasSubscription.unsubscribe();
  }
}
