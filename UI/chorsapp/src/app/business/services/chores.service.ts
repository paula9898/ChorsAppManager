import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChoreResponse } from '../../data/models/chore-response.model';

@Injectable({
  providedIn: 'root',
})
export class ChoresService {
  constructor(private httpClient: HttpClient) {}

  getChores(): Observable<ChoreResponse[]> {
    return this.httpClient.get<ChoreResponse[]>('${environment.apiBaseUrl}');
  }
}
