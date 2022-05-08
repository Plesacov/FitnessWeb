import {  Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @Input() links!: Link[];

  constructor(private _authService: AuthenticationService) {
  }
  ngOnInit(): void {

  }

  logout(): void {
    this._authService.logOut('/api/accounts/logout');
  }
}

interface Link{
  name: string,
  routerLink: string
}


export {Link}