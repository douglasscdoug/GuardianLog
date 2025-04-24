import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Motorista } from '../models/Motorista';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MotoristaService {
  public baseURL = environment.apiUrl + 'api/motorista';

  constructor(private http: HttpClient) { }

  public getMotoristas(): Observable<Motorista[]> {
    return this.http.get<Motorista[]>(this.baseURL).pipe(take(1));
  }
}
