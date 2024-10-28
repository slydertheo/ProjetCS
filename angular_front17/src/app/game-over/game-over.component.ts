import {ChangeDetectionStrategy, Component, inject} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle,
} from '@angular/material/dialog';

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
export class GameOverMessage {}
