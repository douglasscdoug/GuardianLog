import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, take } from 'rxjs';
import { Empresa } from '../models/Empresa';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
  public baseURL = environment.apiUrl + 'api/empresa'

  constructor(private http: HttpClient) { }

  public getEmpresas(): Observable<Empresa[]> {
    return this.http.get<Empresa[]>(this.baseURL).pipe(take(1));
  }

  public getEmpresaById(id: number): Observable<Empresa> {
    return this.http.get<Empresa>(`${this.baseURL}/empresaId/${id}`).pipe(take(1));
  }
}