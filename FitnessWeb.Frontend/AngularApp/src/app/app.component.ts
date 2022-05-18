import { Component } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessProgramViewModel } from 'src/viewModels/fitnessProgramViewModel';
import { Link } from './components/nav-bar/nav-bar.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [FitnessProgramService]
})
export class AppComponent {
  links!: Link[];

  fitnessProgram!: FitnessProgramViewModel;
  title = 'AngularApp';
  constructor(private _authService: AuthenticationService) {
    if (!this._authService.isLoggedIn()) {
      this.links = [
        { name: 'Sign In', routerLink: '/signin' },
        { name: 'Sign Up', routerLink: '/signup' },
        { name: 'About', routerLink: '/about' }];
    }
    else if (this._authService.isLoggedIn() && this._authService.isUserAdmin()) {
      this.links = [
        { name: 'Programs', routerLink: '/admin/fitnessPrograms' },
        { name: 'Fitness Tips', routerLink: '/admin/fitnessTips' },
        { name: 'Trainings', routerLink: '/admin/fitnessTrainings' }];
    }
    else {
      this.links = [{ name: 'About', routerLink: '/about' }];
    }
  }
}
