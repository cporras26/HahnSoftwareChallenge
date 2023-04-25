import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';
import { UserService } from './services/user.service';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserResponse } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'firstName',
    'lastName',
    'age',
    'occupation',
    'actions',
  ];
  dataSource!: MatTableDataSource<UserResponse>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _dialog: MatDialog, private _userService: UserService) {}

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList() {
    this._userService.getUserList().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  openAddEditUserForm(userInformation: any) {
    const dialogRef = this._dialog.open(UserAddEditComponent, {
      data: userInformation,
    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) this.getUserList();
      },
    });
  }

  deleteUser(id: number) {
    this._userService.deleteUser(id).subscribe({
      next: (res) => {
        this.getUserList();
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
