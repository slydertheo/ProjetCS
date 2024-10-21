import { Component, OnInit } from '@angular/core';
import { HelloService } from './services/api.service';

@Component({
  selector: 'app-root',
  template: `<h1>{{ greeting }}</h1>`,
  standalone: true
})
export class AppComponent implements OnInit {
  greeting: string = '';

  constructor(private helloService: HelloService) {}

  ngOnInit() {
    this.helloService.getGreetingMessage().subscribe((data) => {
      this.greeting = data;
    });
  }
}
