import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { ExerciseViewModel } from 'src/viewModels/exerciseViewModel';
import { FilterModel, PageCollectionResponse } from 'src/viewModels/pageCollectionResponse';
import { AddEditFitnessExerciseComponent } from '../add-edit-fitness-exercise/add-edit-fitness-exercise.component';

@Component({
  selector: 'app-fitness-exercise-table',
  templateUrl: './fitness-exercise-table.component.html',
  styleUrls: ['./fitness-exercise-table.component.css']
})
export class FitnessExerciseTableComponent implements OnInit {

  displayedColumns: string[] = ['fitnessTrainingName', 'name', 'countOfRepeats', 'videoUrl', 'actions'];
  fitnessExercises!: ExerciseViewModel[];
  filterModel: FilterModel = { limit: 5, page: 0, term: "", sortedField: 'Name', sortAsc: true };
  length: number = 100;
  pageSize: number = this.filterModel.limit;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pagedResponse!: PageCollectionResponse;
  pageEvent!: PageEvent;


  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort!: MatSort;


  constructor(private fitnessProgramService: FitnessProgramService, public dialog: MatDialog, private _router: Router,
    private toastr: ToastrService,) {
    this.refreshFitnessExercises(this.filterModel);
  }
  ngOnInit(): void {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    var filter = { ...this.filterModel };
    filter.term = filterValue;
    this.refreshFitnessExercises(filter);
  }

  refreshFitnessExercises(filterModel: FilterModel): void {
    this.fitnessProgramService
      .getPagedFitnessExercises(filterModel)
      .subscribe((res: PageCollectionResponse) => {
        this.fitnessExercises = res.items;
        this.pagedResponse = res;
      });
  }

  public onPageChange(event: PageEvent): PageEvent {
    var filter = { ...this.filterModel };
    filter.page = event.pageIndex;
    filter.limit = event.pageSize;
    this.refreshFitnessExercises(filter);
    return event;
  }

  public sortData(sort: Sort) {
    var filter = { ...this.filterModel };
    const isAsc = sort.direction === 'asc';
    filter.sortAsc = isAsc;
    switch (sort.active) {
      case 'name':
        filter.sortedField = "Name";
        break;
      case 'countOfRepeats':
        filter.sortedField = "CountOfRepeats";
        break;
      default: filter.sortedField = "Name";
        break;
    }
    this.refreshFitnessExercises(filter);
  }
  openDialog(fitnessExerciseViewModel?: ExerciseViewModel) {
    const dialogConfig = new MatDialogConfig();

    if (fitnessExerciseViewModel != null) {
      dialogConfig.data = {
        fitnessExerciseViewModel: fitnessExerciseViewModel
      };
    }
    this.dialog.open(AddEditFitnessExerciseComponent, dialogConfig);

  }
  public deleteFitnessExercise = (id: number) => {
    this.fitnessProgramService.deleteFitnessExercise(id).subscribe
      (() => {
        this.showSuccess('Deleted successfull');
        this.refresh();
      },
        () => {
          this.toastr.error("IT Error");
        })
  }

  showSuccess(message: string) {
    this.toastr.success(`${message}`, 'Success');
  }

  refresh(): void {
    this._router.navigate(["/admin/fitnessExercises"]).then(() => {
      window.location.reload();
    }
    )
  }
}
