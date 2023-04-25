import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'angular-app';

  constructor(private _dialog: MatDialog) {}

  openAddEditUserForm() {
    this._dialog.open(UserAddEditComponent);
  }
}
