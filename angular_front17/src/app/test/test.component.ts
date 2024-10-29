import { Component, OnInit, HostListener, OnDestroy } from '@angular/core';
import { GridService } from '../grid.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  imports: [CommonModule]
})
export class TestComponent implements OnInit, OnDestroy {
  grid: number[][] = [];
  currentKey: string = 'r';
  intervalId: any;
  hasStartedSending = false;

  constructor(private gridService: GridService, private http: HttpClient) {}

  ngOnInit() {
    this.getGrid();
  }

  getGrid() {
    this.gridService.getGrid().subscribe({
      next: (data) => {
        this.grid = data;
        console.log(this.grid);
      },
      error: (err) => {
        console.error('Error fetching grid:', err);
      },
      complete: () => {
        console.log('Fetching grid complete.');
      }
    });
  }

  getCellClass(cell: number): string {
    if (cell === 9) {
      return 'textured-nine';
    }
    else if (cell === 0) {
      return 'textured-zero';
    }
    else if (cell === 1) {
      return 'textured-one' ;
    }
    return '';
  }

  @HostListener('window:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key !== this.currentKey) {
      this.currentKey = event.key;
    }
    if (!this.hasStartedSending) {
      this.startSendingKey();
      this.hasStartedSending = true;
    }
  }

  startSendingKey() {
    this.intervalId = setInterval(() => {
      this.sendKeyToServer(this.currentKey);
    }, 500); // Envoie toutes les 0.5 secondes
  }

  sendKeyToServer(key: string) {
    this.http.post('http://localhost:5002/api/grid', { key })
      .subscribe(response => {
        this.getGrid();
        console.log('Key sent to server:', response);
      });
  }

  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
}
