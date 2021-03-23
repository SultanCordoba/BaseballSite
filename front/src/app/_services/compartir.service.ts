import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompartirService {

    private tituloNav = new Subject<string>();

    tituloNav$ = this.tituloNav.asObservable();

  constructor() { }

  anuncioTitulo(titulo: string) {
      this.tituloNav.next(titulo);
  }
}
