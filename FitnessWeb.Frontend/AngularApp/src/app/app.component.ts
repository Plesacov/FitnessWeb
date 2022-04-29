import { Component } from '@angular/core';
import { Observable, Observer } from 'rxjs';
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
  links: Link[] = [
    {name: 'Sign In', routerLink: '/signin'},
    {name: 'Sign Up', routerLink: '/signup'},
    {name: 'About', routerLink: '/about'}];
  fitnessProgram!: FitnessProgramViewModel;
  title = 'AngularApp';
  constructor(){
  }

}
