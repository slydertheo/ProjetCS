import { Component, OnInit, HostListener, OnDestroy } from '@angular/core';
import { GridService } from '../grid.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ButtonGameOver } from'../game-over/game-over.component';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  imports: [CommonModule]
})
export class TestComponent implements OnInit, OnDestroy{
  grid: number[][] = [];
  currentKey: string = 'r';
  intervalId: any;
  hasStartedSending = false;
  gameover: ButtonGameOver;

  constructor(private gridService: GridService, private http: HttpClient) {
    this.gameover = new ButtonGameOver();
  }

  ngOnInit() {
    this.getGrid();
  }

  getGrid() {
    this.gridService.getGrid().subscribe({
      next: (data) => {
        this.grid = data;
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
    else if (cell === 8) {
      return 'textured-height';
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
    }, 200); // Envoie toutes les 0.5 secondes
  }

  sendKeyToServer(key: string) {
    this.http.post('http://localhost:5002/api/grid', { key })
      .subscribe(response => {
        if (response == 1){
          console.log("nulllll");
          this.gameover.openDialog();
          if (this.intervalId) {
            clearInterval(this.intervalId);
          }
        }
        else{
          this.getGrid();
        }
      });
  }

  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
}


