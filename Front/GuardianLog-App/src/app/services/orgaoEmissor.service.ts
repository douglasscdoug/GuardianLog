import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { OrgaoEmissor } from '../models/OrgaoEmissor';

@Injectable({
  providedIn: 'root'
})
export class OrgaoEmissorService {
  public baseURL = environment.apiUrl + 'api/OrgaoEmissor';

  constructor(private http: HttpClient) { }

  public getOrgaos(): Observable<OrgaoEmissor[]> {
    return this.http.get<OrgaoEmissor[]>(this.baseURL).pipe(take(1));
  }
}
