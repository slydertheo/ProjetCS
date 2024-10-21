import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HelloService {
  constructor(private http: HttpClient) {}

  getGreetingMessage(): Observable<string> {
    return this.http.get<string>('http://localhost:5082/api/greeting'); // Replace with your actual endpoint
  }
}


