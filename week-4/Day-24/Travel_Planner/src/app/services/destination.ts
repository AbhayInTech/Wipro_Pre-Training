import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DestinationService {
  private baseUrl = 'https://689da66ece755fe69789615c.mockapi.io/dest/';

  constructor(private http: HttpClient) {}

  getDestinations(endpoint: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${endpoint}`);
  }
}
