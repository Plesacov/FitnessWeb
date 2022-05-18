import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Person } from 'src/app/components/profile-page/person';
import { CreateFitnessProgramCommand } from 'src/commands/createFitnessProgramCommand';
import { headers, RegistrationResponseDto, UserForAuthenticationDto, UserForRegistrationDto } from '../app/components/sign-in/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  createOrEditProgram(arg0: string, CreateFitnessProgramCommand: CreateFitnessProgramCommand) {
    throw new Error('Method not implemented.');
  }
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient) { }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this._http.post(route, body);
  }
  public getUserdata = (): Observable<Person>  => {
    const token: any = localStorage.getItem('token');
    var email:string = this.parseJwt(token).username;
    return this._http.post<Person>(`/api/accounts/getUserdata`, {email: email});
  }

  public uploadPhoto = (file: File): Observable<any>  => {
    const token: any = localStorage.getItem('token');
    var id:number = this.parseJwt(token).id;
    return this._http.post<any>(`/api/accounts/uploadPhoto`, {file: file, userId: id});
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

  isUserAdmin(): boolean {
    const token: any = localStorage.getItem('token');
    var isAdmin:string = this.parseJwt(token).isAdmin;
    return isAdmin === 'true';
  }

  parseJwt (token: string) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};
}
