import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { UserProfileModel } from '../models/userProfileModel';
import { UserLoginModel } from '../models/userLoginModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.baseUrl;
  private httpOptions: any;
  constructor(private http: HttpClient) {

    // this.httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json'
    //   })
    // };
  }

  registerUser(model: UserProfileModel) {
    console.log(JSON.stringify(model));
    return this.http.post(`${this.baseUrl}/auth/register`, JSON.stringify(model));

  }

  loginUser(model: UserLoginModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    console.log(JSON.stringify(model));
    return this.http.post(`${this.baseUrl}/auth/login`, JSON.stringify(model), this.httpOptions);

  }

  resetPassword(model: any) {
    console.log(JSON.stringify(model));
    return this.http.post(`${this.baseUrl}/auth/resetpassword`, JSON.stringify(model));

  }

  userProfile() {
    return this.http.get(`${this.baseUrl}/auth/UserProfile`);

  }
}
