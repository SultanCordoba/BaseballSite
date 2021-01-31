import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Liga } from '../_models/liga';

@Injectable({
  providedIn: 'root'
})
export class LigaService {

  constructor(private httpClient: HttpClient) { }

  public listaLigas(): Observable<Liga[]> {
      return this.httpClient.get<Liga[]>(
        `${environment.apiUrl}/liga`
      );
  }

  public getLiga(id: number): Observable<Liga> {
      return this.httpClient.get<Liga>(
        `${environment.apiUrl}/liga/${id}`
      );
  }
}
