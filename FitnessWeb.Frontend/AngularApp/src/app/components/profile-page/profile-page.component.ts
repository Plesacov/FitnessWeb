import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AssignFitnessProgramCommand } from 'src/commands/assignFitnessProgramCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { DialogComponent } from '../dialog/dialog.component';
import { Person } from './person';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})

export class ProfilePageComponent implements OnInit {
  panelOpenState: boolean = false;
  person!: Person;
  constructor(private _authService: AuthenticationService, public dialog: MatDialog, public fitnessProgramService: FitnessProgramService) {
  }

  ngOnInit(): void {
    this._authService.getUserdata().subscribe((res: Person) => this.person = res);
  }

  openDialog() {
    this.dialog.open(DialogComponent, {
    });
  }
}
