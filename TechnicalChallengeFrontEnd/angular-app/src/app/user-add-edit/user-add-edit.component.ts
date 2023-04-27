import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-user-add-edit',
  templateUrl: './user-add-edit.component.html',
  styleUrls: ['./user-add-edit.component.css'],
})
export class UserAddEditComponent implements OnInit {
  userForm: FormGroup;
  errors: { [key: string]: string } = {
    firstName: 'First name is required.',
    lastName: 'Last name is required.',
    age: 'Age must be a positive value.',
    occupation: 'Occupation is required.',
  };

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _dialogRef: MatDialogRef<UserAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.userForm = this._fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      age: [0, [Validators.required, Validators.min(Number.MIN_VALUE)]],
      occupation: ['', [Validators.required, Validators.maxLength(100)]],
    });
  }

  ngOnInit(): void {
    this.userForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.userForm.valid) {
      if (this.data) {
        this._userService
          .updateUser(this.data.id, this.userForm.value)
          .subscribe({
            next: (res) => {
              this._dialogRef.close(true);
            },
            error(err) {
              console.log(err);
            },
          });
        console.log(this.userForm.value);
      } else {
        this._userService.addUser(this.userForm.value).subscribe({
          next: (res) => {
            this._dialogRef.close(true);
          },
          error(err) {
            console.log(err);
          },
        });
        console.log(this.userForm.value);
      }
    }
  }
}
