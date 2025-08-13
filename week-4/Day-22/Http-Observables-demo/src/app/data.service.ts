import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Data } from '@angular/router';
import { CommonModule, NgFor } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private apiurl = 'https://jsonplaceholder.typicode.com/posts';

  constructor(private http: HttpClient) {}

  getPost(): Observable<any> {
    return this.http.get(this.apiurl);
  }
}
