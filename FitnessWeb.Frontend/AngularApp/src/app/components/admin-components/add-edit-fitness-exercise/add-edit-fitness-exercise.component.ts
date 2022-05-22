import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateFitnessExerciseCommand } from 'src/commands/createFitnessExerciseCommand';
import { CreateFitnessTrainingCommand } from 'src/commands/createFitnessTrainingCommand';
import { UpdateFitnessExerciseCommand } from 'src/commands/updateFitnessExerciseCommand';
import { UpdateFitnessTrainingCommand } from 'src/commands/updateFitnessTrainingCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { ExerciseViewModel } from 'src/viewModels/exerciseViewModel';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';
import { TrainingViewModel } from 'src/viewModels/trainingViewModel';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-add-edit-fitness-exercise',
  templateUrl: './add-edit-fitness-exercise.component.html',
  styleUrls: ['./add-edit-fitness-exercise.component.css']
})
export class AddEditFitnessExerciseComponent implements OnInit {

  addOrEditForm!: FormGroup;
  fitnessTrainings!: TrainingViewModel[];
  exerciseViewModel: ExerciseViewModel = new ExerciseViewModel(0, '', 0, '', '');
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
      countOfRepeats: new FormControl("", [Validators.required]),
      videoUrl: new FormControl("", [Validators.required]),
      fitnessTraining: new FormControl("", [Validators.required])
    });

    if (_data != null) {
      this.exerciseViewModel = _data.fitnessExerciseViewModel;
    }
  }

  public validateControl = (controlName: string) => {
    return this.addOrEditForm.controls[controlName].invalid && this.addOrEditForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.addOrEditForm.controls[controlName].hasError(errorName)
  }

  ngOnInit(): void {
    this._returnUrl = '/admin/fitnessExercises';
    this.fitnessProgramService.getAllFitnessTrainings().subscribe((res: TrainingViewModel[]) => this.fitnessTrainings = res);
  }

  public createOrEditFitnessExercise = (formValue: any) => {
    if (formValue.name === "") {
      return;
    }
    const command = { ...formValue };
    const createOrEditFitnessExercise: CreateFitnessExerciseCommand = {
      name: command.name,
      countOfRepeats: command.countOfRepeats,
      videoUrl: command.videoUrl,
      fitnessTrainingId: command.fitnessTraining
    }
    if (this.exerciseViewModel.id === 0) {
      this.fitnessProgramService.createFitnessExercise(createOrEditFitnessExercise).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          () => {
            this.toastr.error("IT Error");
          })
    }
    else {
      var editFitnessExercise = new UpdateFitnessExerciseCommand(this.exerciseViewModel.id, createOrEditFitnessExercise.name, createOrEditFitnessExercise.countOfRepeats, createOrEditFitnessExercise.videoUrl);
      this.fitnessProgramService.updateFitnessExercise(editFitnessExercise).subscribe
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
    if (this.exerciseViewModel.id !== 0)
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