import { Component, OnInit } from '@angular/core';
import { SnakeService } from '../snake.service';
import { SnakeData } from '../Models/SnakeModel';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  snakes: SnakeData[] | undefined;

  constructor(private snakeService: SnakeService) {}

  ngOnInit() {
    this.getSnakes();
  }

  getSnakes() {
    this.snakeService.getSnakes().subscribe(
      data => {
        this.snakes = data;
        console.log(this.snakes);
      },
      error => {
        console.error('Erreur dans le composant lors de la récupération des serpents:', error);
      }
    );
  }
}




