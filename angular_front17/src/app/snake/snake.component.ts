import { Component, OnInit } from '@angular/core';
import { SnakeService } from '../snake.service';
import { SnakeData } from '../Models/SnakeModel';

@Component({
  selector: 'app-snake-list',
  standalone: true,
  imports: [],
  templateUrl: './snake-list.component.html',
  styleUrls: ['./snake-list.component.css']
})
export class SnakeListComponent implements OnInit {
  snakes: SnakeData[] = [];

  constructor(private snakeService: SnakeService) {}

  ngOnInit(): void {
    this.snakeService.getSnakes().subscribe(
      (response) => {
        this.snakes = response;
      },
      (error) => {
        console.error('Erreur lors de la récupération des serpents', error);
      }
    );
  }
}
