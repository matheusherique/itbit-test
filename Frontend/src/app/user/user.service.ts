import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Users } from "./user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseURL = "https://localhost:5001/api/user";

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Users> {
    return this.http.get<Users>(this.baseURL);

  }
}
