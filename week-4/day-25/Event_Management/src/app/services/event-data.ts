import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../models/event';

@Injectable({
  providedIn: 'root',
})
export class EventDataService {
  private apiUrl = 'http://localhost:3000/events';

  constructor(private http: HttpClient) {}

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.apiUrl);
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/${id}`);
  }

  getEventByType(type: String): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/${type}`);
  }

  createEvent(event: Event[]): Observable<Event[]> {
    return this.http.post<Event[]>(this.apiUrl, event);
  }
}
