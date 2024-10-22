import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { SnakeData } from '../app/Models/SnakeModel';

@Injectable({
  providedIn: 'root'
})
export class SnakeService {
  private apiUrl = 'http://localhost:5002/api/snakes';

  constructor(private http: HttpClient) {}

  getSnakes(): Observable<SnakeData[]> {
    return this.http.get<SnakeData[]>(this.apiUrl).pipe(
      catchError(error => {
        console.error('Erreur lors de la récupération des serpents:', error);
        throw error;
      })
    );
  }
}
