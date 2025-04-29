import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, take } from 'rxjs';
import { Veiculo } from '../models/Veiculo';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {
  public baseURL = environment.apiUrl + 'api/veiculo'

  constructor(private http: HttpClient) { }

  public getVeiculos(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.baseURL).pipe(take(1));
  }
}