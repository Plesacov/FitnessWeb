import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { RegistrationResponseDto, UserForAuthenticationDto, UserForRegistrationDto } from '../app/components/sign-in/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient) { }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this._http.post(route, body);
  }

  public logOut = (route: string) => {
    return this._http.post(route, {});
  }

  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto>(route, body);
  }

  isLoggedIn() {
    const token: any = localStorage.getItem('token'); // get token from local storage
    if (token) {
      const payload = atob(token.split('.')[1]); // decode payload of token
      const parsedPayload = JSON.parse(payload); // convert payload into an Object

      return parsedPayload.exp > Date.now() / 1000; // check if token is expired
    }
    else {
      return false;
    }
  }
}
