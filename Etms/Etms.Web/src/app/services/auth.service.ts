import { Injectable } from '@angular/core';
// import { tokenNotExpired, JwtHelper } from 'angular2-jwt/angular2-jwt';
import { JwtHelperService } from "@auth0/angular-jwt";
import { map, retry } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DataService } from './data.service';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class AuthService extends DataService {
  
  helper = new JwtHelperService();

  currentUser: any;
  registerUrl = 'user/register';
  authenticateUrl = 'user/authenticate';

  apiPort = environment.apiPort;
  baseUrl = `http://${window.location.hostname}${this.apiPort}/api/`;

  constructor(http: HttpClient) {
    super('/', http);
    let token = localStorage.getItem('token');
    if (token) {
      let jwt = new JwtHelperService();
      this.currentUser = jwt.decodeToken(token);
    }
  }

  signup(formData: any) {
    this.url = this.baseUrl + this.registerUrl;
    return this.create(formData);
    //return this.http.post(url, JSON.stringify(formData));
  }

  login(credentials: any) {
    this.url = this.baseUrl + this.authenticateUrl;
    return this.create(credentials)
      // return this.http.post('/authenticate', JSON.stringify(credentials))
      .pipe(
        map((result: any) => {
          if (result && result.token) {
            localStorage.setItem('token', result.token);
            let jwt = new JwtHelperService();
            this.currentUser = jwt.decodeToken(localStorage.getItem('token') || "");
            return true;
          }
          else {
            return false
          };
        }));
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = null;
  }

  isLoggedIn() {
    let token = localStorage.getItem('token');
    return !this.helper.isTokenExpired(token || "");
  }
}
