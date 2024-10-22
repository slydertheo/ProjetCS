import { Component } from '@angular/core';
import { SnakeComponent } from './snake/snake.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports:[
    SnakeComponent
  ]
})
export class AppComponent {
  title = 'Mon Application Angular';
}

