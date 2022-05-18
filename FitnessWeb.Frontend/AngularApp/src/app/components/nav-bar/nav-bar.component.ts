import {  Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @Input() links!: Link[];
  isUserLoggedIn!: boolean;
  isAdmin!: boolean;

  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.isUserLoggedIn = this._authService.isLoggedIn();
    this.isAdmin = this._authService.isUserAdmin();
  }

  logout(): void {
    localStorage.removeItem('token');
    this.refresh();
  }
  refresh(): void {
    this._router.navigate(['/signin']).then(() => {
      window.location.reload();
    }
    )}
}

interface Link{
  name: string,
  routerLink: string
}


export {Link}