import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { TestComponent } from '../app/test/test.component'; // Vérifiez le chemin
import { SnakeService } from '../app/snake.service';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent // Ajoutez TestComponent ici
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    TestComponent
  ],
  providers: [SnakeService],
  bootstrap: [AppComponent]
})
export class AppModule { }

