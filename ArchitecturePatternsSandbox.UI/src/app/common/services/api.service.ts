import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:7241/api';

  constructor(private httpClient: HttpClient) {}

  get<T>(endpoint: string): Observable<T> {
    return this.httpClient.get<T>(`${this.apiUrl}/${endpoint}`);
  }

  post<T, D>(endpoint: string, data: D): Observable<T> {
    return this.httpClient.post<T>(`${this.apiUrl}/${endpoint}`, data);
  }

  put<T, D>(endpoint: string, data: D): Observable<T> {
    return this.httpClient.put<T>(`${this.apiUrl}/${endpoint}`, data);
  }
}
