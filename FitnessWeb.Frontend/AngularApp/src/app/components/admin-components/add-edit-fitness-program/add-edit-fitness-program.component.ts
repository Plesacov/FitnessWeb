import { Inject, Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateFitnessProgramCommand } from 'src/commands/createFitnessProgramCommand';
import { DeleteFitnessProgramCommand } from 'src/commands/deleteFitnessProgramCommand';
import { UpdateFitnessProgramCommand } from 'src/commands/updateFitnessProgramCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-add-edit-fitness-program',
  templateUrl: './add-edit-fitness-program.component.html',
  styleUrls: ['./add-edit-fitness-program.component.css']
})
export class AddEditFitnessProgramComponent implements OnInit {
  addOrEditForm!: FormGroup;
  fitnessType: FitnessTypeViewModel = new FitnessTypeViewModel("", "", 0);
  private _returnUrl!: string;
  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    private _authService: AuthenticationService,
    public fitnessProgramService: FitnessProgramService,
    private _router: Router,
    private toastr: ToastrService,
    private _route: ActivatedRoute,
    @Inject(MAT_DIALOG_DATA) _data: any
  ) {
    this.addOrEditForm = new FormGroup({
      name: new FormControl("", [Validators.required]),
      description: new FormControl("", [Validators.required])
    });

    if (_data != null) {
      this.fitnessType = _data.fitnessTypeViewModel;
    }
  }


  public validateControl = (controlName: string) => {
    return this.addOrEditForm.controls[controlName].invalid && this.addOrEditForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.addOrEditForm.controls[controlName].hasError(errorName)
  }

  ngOnInit(): void {
    this._returnUrl = '/admin/fitnessPrograms';
  }

  public createOrEditProgram = (formValue: any) => {
    const login = { ...formValue };
    const createOrEditProgram: CreateFitnessProgramCommand = {
      name: login.name,
      description: login.description
    }
    if (this.fitnessType.id === 0) {
      this.fitnessProgramService.createFitnessProgram(createOrEditProgram).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          () => {
            this.toastr.error("IT Error");
          })
    }
    else {
      var editFitnessProgram = new UpdateFitnessProgramCommand(createOrEditProgram.name, createOrEditProgram.description, this.fitnessType.id);
      this.fitnessProgramService.updateFitnessProgram(editFitnessProgram).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          () => {
            this.toastr.error("IT Error");
          })
    }
    this.dialogRef.close();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  showSuccess(message: string) {
    this.toastr.success(`${message}`, 'Success');
  }


  refresh(): void {
    this._router.navigate([this._returnUrl]).then(() => {
      window.location.reload();
    }
    )
  }
}


