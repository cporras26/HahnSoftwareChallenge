import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user-add-edit',
  templateUrl: './user-add-edit.component.html',
  styleUrls: ['./user-add-edit.component.css'],
})
export class UserAddEditComponent {
  userForm: FormGroup;

  constructor(private _fb: FormBuilder) {
    this.userForm = this._fb.group({
      firstName: '',
      lastName: '',
      age: 0,
      occupation: '',
    });
  }

  onFormSubmit() {
    if (this.userForm.valid) {
      console.log(this.userForm.value);
    }
  }
}
