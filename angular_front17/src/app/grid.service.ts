import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  private apiUrl = 'http://localhost:5002/api/grid';

  constructor(private http: HttpClient) {}

  getGrid(): Observable<number[][]> {
    return this.http.get<number[][]>(this.apiUrl);
  }
}
