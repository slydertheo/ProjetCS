import { Component, OnInit } from '@angular/core';
import { SnakeService } from '../snake.service';
import { SnakeData } from '../Models/SnakeModel';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  imports:[
    CommonModule,
  ]
})
export class TestComponent implements OnInit {
  snakes: SnakeData[] = [] ;

  constructor(private snakeService: SnakeService) {}

  ngOnInit() {
    this.getSnakes();
  }

  getSnakes() {
    this.snakeService.getSnakes().subscribe({
      next: (data) => {
        this.snakes = data;
        console.log(this.snakes);
      },
      error: (err) => {
        console.error('Error fetching snakes:', err);
      },
      complete: () => {
        console.log('Fetching snakes complete.');
      }
    });    
  }
}
