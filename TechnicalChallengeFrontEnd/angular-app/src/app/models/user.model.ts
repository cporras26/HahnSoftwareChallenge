export interface UserRequest {
  id?: number;
  firstName: string;
  lastName: string;
  age: number;
  occupation: string;
}

export interface UserResponse {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
  occupation: string;
}
