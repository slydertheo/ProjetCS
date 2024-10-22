// src/app/snake/snake.component.ts
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Snake {
  id: number;
  size: string;
  direction: string;
}

@Component({
  selector: 'snake',
  templateUrl: './snake.component.html',
  styleUrls: ['./snake.component.css']
})
export class SnakeComponent {
  snakes: Snake[] = [];

  constructor(private http: HttpClient) {
    this.getSnakes().subscribe(data => {
      this.snakes = data;
    });
  }

  getSnakes(): Observable<Snake[]> {
    return this.http.get<Snake[]>('http://localhost:5204/api/snake');
  }
}
