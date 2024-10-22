// src/app/app.module.ts
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { provideHttpClient } from '@angular/common/http';
import { SnakeComponent } from './snake/snake.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    SnakeComponent,
    AppComponent 
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
