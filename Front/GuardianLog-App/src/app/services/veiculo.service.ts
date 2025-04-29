import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, take } from 'rxjs';
import { Veiculo } from '../models/Veiculo';
import { Cor } from '../models/Cor';
import { MarcaVeiculo } from '../models/MarcaVeiculo';
import { ModeloVeiculo } from '../models/ModeloVeiculo';
import { Tecnologia } from '../models/Tecnologia';
import { TipoCarreta } from '../models/TipoCarreta';
import { TipoVeiculo } from '../models/TipoVeiculo';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {
  public baseURL = environment.apiUrl + 'api/veiculo'

  constructor(private http: HttpClient) { }

  public getVeiculos(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.baseURL).pipe(take(1));
  }

  public getVeiculoById(id:number): Observable<Veiculo> {
    return this.http.get<Veiculo>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(Veiculo: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(this.baseURL, Veiculo).pipe(take(1));
  }

  public put(Veiculo: Veiculo): Observable<Veiculo> {
    return this.http.put<Veiculo>(this.baseURL, Veiculo).pipe(take(1));
  }

  public getCores(): Observable<Cor[]> {
    return this.http.get<Cor[]>(`${this.baseURL}/Cores`).pipe(take(1));
  }

  public getMarcas(): Observable<MarcaVeiculo[]> {
    return this.http.get<MarcaVeiculo[]>(`${this.baseURL}/Marcas`).pipe(take(1));
  }

  public getModeloByMarcaId(marcaId: number): Observable<ModeloVeiculo[]> {
    return this.http.get<ModeloVeiculo[]>(`${this.baseURL}/ModelosByMarca/${marcaId}`).pipe(take(1));
  }

  public getTecnologias(): Observable<Tecnologia[]> {
    return this.http.get<Tecnologia[]>(`${this.baseURL}/Tecnologias`).pipe(take(1));
  }

  public getTiposCarreta(): Observable<TipoCarreta[]> {
    return this.http.get<TipoCarreta[]>(`${this.baseURL}/TiposCarreta`).pipe(take(1));
  }

  public getTiposVeiculo(): Observable<TipoVeiculo[]> {
    return this.http.get<TipoVeiculo[]>(`${this.baseURL}/TiposVeiculo`).pipe(take(1));
  }
}