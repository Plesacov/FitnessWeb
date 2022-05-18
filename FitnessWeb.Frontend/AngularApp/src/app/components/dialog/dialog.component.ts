import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AssignFitnessProgramCommand } from 'src/commands/assignFitnessProgramCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})


export class DialogComponent {
  fitnessTypes!: FitnessTypeViewModel[];
  fitnessLevels: string[] = ["Beginner", "Middle", "Advanced"];
  selectedType!: FitnessTypeViewModel;
  selectedFitnessLevel!: string;
  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    private _authService: AuthenticationService,
    public fitnessProgramService: FitnessProgramService,
    private _router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.fitnessProgramService.getAllFitnessTypes().subscribe((res: FitnessTypeViewModel[]) => this.fitnessTypes = res);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  assignFitnessProgram(fitnessTypeId: number, fitnessLevel: string) {
    const token: any = localStorage.getItem('token');
    var userId: number = this._authService.parseJwt(token).id;
    var command = new AssignFitnessProgramCommand(fitnessTypeId, userId, fitnessLevel);
    this.fitnessProgramService.assignFitnessProgram(command).subscribe((res: any) => {
      this.showSuccess();
      this.dialogRef.close();
      this.refresh();
    },
      (error: string) => {
        this.showError(error)
      });
  }

  onClickOk(): void {
    this.assignFitnessProgram(this.selectedType.id, this.selectedFitnessLevel);
  }

  showSuccess() {
    this.toastr.success('Thank you for your choise', 'Success');
  }

  showError(error: string) {
    this.toastr.error(`${error}`, 'ERROR');
  }

  refresh(): void {
    this._router.navigate(['/page']).then(() => {
      window.location.reload();
    }
    )
  }
}
