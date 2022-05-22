import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateFitnessTipCommand } from 'src/commands/createFitnessTipCommand';
import { CreateFitnessTrainingCommand } from 'src/commands/createFitnessTrainingCommand';
import { UpdateFitnessTipCommand } from 'src/commands/updateFitnessTipCommand';
import { UpdateFitnessTrainingCommand } from 'src/commands/updateFitnessTrainingCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTipViewModel } from 'src/viewModels/fitnessTipViewModel';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';
import { TrainingViewModel } from 'src/viewModels/trainingViewModel';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-add-edit-fitness-training',
  templateUrl: './add-edit-fitness-training.component.html',
  styleUrls: ['./add-edit-fitness-training.component.css']
})
export class AddEditFitnessTrainingComponent implements OnInit {

  addOrEditForm!: FormGroup;
  fitnessTypes!: FitnessTypeViewModel[];
  fitnessTraining: TrainingViewModel = new TrainingViewModel('', [], 0, '', 0);
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
      type: new FormControl("", [Validators.required]),
      duration: new FormControl("", [Validators.required]),
      fitnessType: new FormControl("", [Validators.required])
    });

    if (_data != null) {
      this.fitnessTraining = _data.fitnessTrainingViewModel;
    }
  }

  public validateControl = (controlName: string) => {
    return this.addOrEditForm.controls[controlName].invalid && this.addOrEditForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.addOrEditForm.controls[controlName].hasError(errorName)
  }

  ngOnInit(): void {
    this._returnUrl = '/admin/fitnessTrainings';
    this.fitnessProgramService.getAllFitnessTypes().subscribe((res: FitnessTypeViewModel[]) => this.fitnessTypes = res);
  }

  public createOrEditFitnessTraining = (formValue: any) => {
    if (formValue.name === "") {
      return;
    }
    const command = { ...formValue };
    const createOrEditTraining: CreateFitnessTrainingCommand = {
      type: command.type,
      duration: command.duration,
      fitnessProgramId: command.fitnessType
    }
    if (this.fitnessTraining.id === 0) {
      this.fitnessProgramService.createFitnessTraining(createOrEditTraining).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          () => {
            this.toastr.error("IT Error");
          })
    }
    else {
      var editFitnessProgram = new UpdateFitnessTrainingCommand(createOrEditTraining.type, createOrEditTraining.duration, this.fitnessTraining.id);
      this.fitnessProgramService.updateFitnessTraining(editFitnessProgram).subscribe
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
    if (this.fitnessTraining.id !== 0)
      this.refresh();
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