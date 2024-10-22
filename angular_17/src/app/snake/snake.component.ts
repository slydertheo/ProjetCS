import { Component, OnInit } from '@angular/core';
import { SnakeService } from '../services/snake.service';
import { SnakeData } from '../models/snake.model';

@Component({
  selector: 'app-snake',
  templateUrl: './snake.component.html',
  styleUrls: ['./snake.component.css'],
  standalone: true
})
export class SnakeComponent implements OnInit {
  snakes: SnakeData[] = [];

  constructor(private snakeService: SnakeService) {}

  ngOnInit(): void {
    this.snakeService.getAllSnakes().subscribe(data => {
      this.snakes = data;
    });
  }
}

