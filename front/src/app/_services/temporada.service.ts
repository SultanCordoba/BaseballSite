import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Temporada } from '../_models/liga';

@Injectable({
  providedIn: 'root'
})
export class TemporadaService {

  constructor(private httpClient: HttpClient) { }

    public getTemporada(id: number): Observable<Temporada> {
        return this.httpClient.get<Temporada>(
            `${environment.apiUrl}/temporada/${id}`
        );
    }
}
