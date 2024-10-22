// src/app/services/snake.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Snake } from '../model/snake.model';

@Injectable({
  providedIn: 'root'
})
export class SnakeService {
  private apiUrl = 'http://localhost:5204/api/snake'; // Changez l'URL selon votre API

  constructor(private http: HttpClient) {}

  getSnakes(): Observable<Snake[]> {
    return this.http.get<Snake[]>(this.apiUrl);
  }
}
