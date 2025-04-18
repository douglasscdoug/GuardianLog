import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { Estado } from '../models/Estado';

@Injectable({
  providedIn: 'root'
})
export class EstadoService {
  public baseURL = environment.apiUrl + 'api/estado';

  constructor(private http: HttpClient) { }

  public getEstadosByPaisId(paisId: number): Observable<Estado[]> {
    return this.http.get<Estado[]>(`${this.baseURL}/${paisId}`).pipe(take(1));
  }
}
