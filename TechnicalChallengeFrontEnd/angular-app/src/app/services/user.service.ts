import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRequest, UserResponse } from '../models/user.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  usersEndpoint = `${environment.baseUrl}Users`;

  constructor(private _http: HttpClient) {}

  getUserList(): Observable<Array<UserResponse>> {
    const url = this.usersEndpoint;
    const observableInfo = new Observable<Array<UserResponse>>((observer) => {
      this._http.get<Array<UserResponse>>(url).subscribe({
        next(response) {
          observer.next(response);
          observer.complete();
        },
        error(error) {
          observer.error(error);
        },
      });
    });
    return observableInfo;
  }

  addUser(user: UserRequest): Observable<boolean> {
    const url = this.usersEndpoint;
    const observableInfo = new Observable<boolean>((observer) => {
      this._http.post<boolean>(url, user).subscribe({
        next(response) {
          observer.next(response);
          observer.complete();
        },
        error(error) {
          observer.error(error);
        },
      });
    });
    return observableInfo;
  }

  updateUser(id: number, user: UserRequest): Observable<boolean> {
    const url = `${this.usersEndpoint}/${id}`;
    const observableInfo = new Observable<boolean>((observer) => {
      this._http.put<boolean>(url, user).subscribe({
        next(response) {
          observer.next(response);
          observer.complete();
        },
        error(error) {
          observer.error(error);
        },
      });
    });
    return observableInfo;
  }

  deleteUser(id: number): Observable<boolean> {
    const url = `${this.usersEndpoint}/${id}`;
    const observableInfo = new Observable<boolean>((observer) => {
      this._http.delete<boolean>(url).subscribe({
        next(response) {
          observer.next(response);
          observer.complete();
        },
        error(error) {
          observer.error(error);
        },
      });
    });
    return observableInfo;
  }
}
