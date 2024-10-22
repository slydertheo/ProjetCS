import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SnakeData } from '../models/snake.model';

@Injectable({
  providedIn: 'root',
})
export class SnakeService {
  private apiUrl = 'http://localhost:5002/api/snakes';

  constructor(private http: HttpClient) {}

  getAllSnakes(): Observable<SnakeData[]> {
    return this.http.get<SnakeData[]>(this.apiUrl);
  }
}
