import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { HttpClient } from '@angular/common/http';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle,
} from '@angular/material/dialog';
import { response } from 'express';
import { error } from 'console';

/**
 * @title Dialog elements
 */
@Component({
  selector: 'app-game-over-button',
  templateUrl: './game-over-button.component.html',
  standalone: true,
  imports: [MatButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ButtonGameOver {

  readonly dialog = inject(MatDialog);

  openDialog() {
    this.dialog.open(GameOverMessage);
  }

}

@Component({
  selector: 'app-game-over',
  templateUrl: './game-over.component.html',
  standalone: true,
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GameOverMessage {

  readonly http = inject(HttpClient);

  restart(){
    console.log('try to restart');
    this.http.post('http://localhost:5002/api/grid/restart',{}, { responseType: 'text' } )
    .subscribe({
      next: (response) => {
        console.log("Game restarted", response);
      },
      error: (error) => {
        console.error("error restarting", error);
      }
    })
  }
}
