import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTipViewModel } from 'src/viewModels/fitnessTipViewModel';
import { FilterModel, PageCollectionResponse } from 'src/viewModels/pageCollectionResponse';
import { TrainingViewModel } from 'src/viewModels/trainingViewModel';
import { AddEditFitnessTipComponent } from '../add-edit-fitness-tip/add-edit-fitness-tip.component';
import { AddEditFitnessTrainingComponent } from '../add-edit-fitness-training/add-edit-fitness-training.component';

@Component({
  selector: 'app-fitness-training-table',
  templateUrl: './fitness-training-table.component.html',
  styleUrls: ['./fitness-training-table.component.css']
})
export class FitnessTrainingTableComponent implements OnInit {

  displayedColumns: string[] = ['fitnessProgramName', 'type', 'duration', 'actions'];
  fitnessTrainings!: TrainingViewModel[];
  filterModel: FilterModel = { limit: 5, page: 0, term: "", sortedField: 'Type', sortAsc: true };
  length: number = 100;
  pageSize: number = this.filterModel.limit;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pagedResponse!: PageCollectionResponse;
  pageEvent!: PageEvent;


  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort!: MatSort;


  constructor(private fitnessProgramService: FitnessProgramService, public dialog: MatDialog, private _router: Router,
    private toastr: ToastrService,) {
    this.refreshFitnessTrainings(this.filterModel);
  }
  ngOnInit(): void {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    var filter = { ...this.filterModel };
    filter.term = filterValue;
    this.refreshFitnessTrainings(filter);
  }

  refreshFitnessTrainings(filterModel: FilterModel): void {
    this.fitnessProgramService
      .getPagedFitnessTrainings(filterModel)
      .subscribe((res: PageCollectionResponse) => {
        this.fitnessTrainings = res.items;
        this.pagedResponse = res;
      });
  }

  public onPageChange(event: PageEvent): PageEvent {
    var filter = { ...this.filterModel };
    filter.page = event.pageIndex;
    filter.limit = event.pageSize;
    this.refreshFitnessTrainings(filter);
    return event;
  }

  public sortData(sort: Sort) {
    var filter = { ...this.filterModel };
    const isAsc = sort.direction === 'asc';
    filter.sortAsc = isAsc;
    switch (sort.active) {
      case 'type':
        filter.sortedField = "Type";
        break;
      case 'duration':
        filter.sortedField = "Duration";
        break;
      default: filter.sortedField = "Type";
        break;
    }
    this.refreshFitnessTrainings(filter);
  }
  openDialog(fitnessTrainingViewModel?: TrainingViewModel) {
    const dialogConfig = new MatDialogConfig();

    if (fitnessTrainingViewModel != null) {
      dialogConfig.data = {
        fitnessTrainingViewModel: fitnessTrainingViewModel
      };
    }
    this.dialog.open(AddEditFitnessTrainingComponent, dialogConfig);

  }
  public deleteFitnessTraining = (id: number) => {
    this.fitnessProgramService.deleteFitnessTraining(id).subscribe
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
    this._router.navigate(["/admin/fitnessTrainings"]).then(() => {
      window.location.reload();
    }
    )
  }
}
