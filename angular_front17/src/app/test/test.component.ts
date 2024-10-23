import { Component, OnInit } from '@angular/core';
import { GridService } from '../grid.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-test',
  standalone: true,
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
  imports: [
    CommonModule,
  ]
})
export class TestComponent implements OnInit {
  grid: number[][] = [];

  constructor(private gridService: GridService) {}

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
    } else if (cell === 0) {
      return 'textured-zero';
    }
    return '';
  }
  
}

