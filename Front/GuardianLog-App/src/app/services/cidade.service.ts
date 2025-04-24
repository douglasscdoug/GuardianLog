import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, take } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Estado } from '../models/Estado';
import { Cidade } from '../models/Cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {
  public baseURL = environment.apiUrl + 'api/cidade';

  constructor(private http: HttpClient) { }

  public getCidadesByEstadoId(estadoId: number): Observable<Cidade[]> {
    return this.http.get<Cidade[]>(`${this.baseURL}/estadoId/${estadoId}`).pipe(take(1));
  }
}
