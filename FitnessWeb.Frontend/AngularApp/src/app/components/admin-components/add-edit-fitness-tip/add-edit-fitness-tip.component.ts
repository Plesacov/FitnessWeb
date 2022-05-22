import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CreateFitnessProgramCommand } from 'src/commands/createFitnessProgramCommand';
import { CreateFitnessTipCommand } from 'src/commands/createFitnessTipCommand';
import { UpdateFitnessProgramCommand } from 'src/commands/updateFitnessProgramCommand';
import { UpdateFitnessTipCommand } from 'src/commands/updateFitnessTipCommand';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTipViewModel } from 'src/viewModels/fitnessTipViewModel';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';
import { DialogComponent } from '../../dialog/dialog.component';

@Component({
  selector: 'app-add-edit-fitness-tip',
  templateUrl: './add-edit-fitness-tip.component.html',
  styleUrls: ['./add-edit-fitness-tip.component.css']
})
export class AddEditFitnessTipComponent implements OnInit {
  addOrEditForm!: FormGroup;
  fitnessTypes!: FitnessTypeViewModel[];
  fitnessTip: FitnessTipViewModel = new FitnessTipViewModel('', '', '', 0);
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
      description: new FormControl("", [Validators.required]),
      fitnessType: new FormControl("", [Validators.required])
    });

    if (_data != null) {
      this.fitnessTip = _data.fitnessTipViewModel;
    }
  }


  public validateControl = (controlName: string) => {
    return this.addOrEditForm.controls[controlName].invalid && this.addOrEditForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.addOrEditForm.controls[controlName].hasError(errorName)
  }

  ngOnInit(): void {
    this._returnUrl = '/admin/fitnessTips';
    this.fitnessProgramService.getAllFitnessTypes().subscribe((res: FitnessTypeViewModel[]) => this.fitnessTypes = res);
  }

  public createOrEditFitnessTip = (formValue: any) => {
    if (formValue.name === "") {
      return;
    }
    const command = { ...formValue };
    const createOrEditTip: CreateFitnessTipCommand = {
      name: command.name,
      description: command.description,
      fitnessProgramId: command.fitnessType
    }
    if (this.fitnessTip.id === 0) {
      this.fitnessProgramService.createFitnessTip(createOrEditTip).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          () => {
            this.toastr.error("IT Error");
          })
    }
    else {
      var editFitnessProgram = new UpdateFitnessTipCommand(createOrEditTip.name, createOrEditTip.description, this.fitnessTip.id);
      this.fitnessProgramService.updateFitnessTip(editFitnessProgram).subscribe
        (() => {
          this.showSuccess('Created successfull');
          this.refresh();
        },
          (error) => {
            this.toastr.error(error);
            console.log(error);
          })
    }
    this.dialogRef.close();
  }

  onNoClick(): void {
    this.dialogRef.close();
    if (this.fitnessTip.id !== 0)
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


