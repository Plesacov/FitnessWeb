import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTypeViewModel } from 'src/viewModels/fitnessTypeViewModel';
import { FilterModel, PageCollectionResponse } from 'src/viewModels/pageCollectionResponse';
import { AddEditFitnessProgramComponent } from '../add-edit-fitness-program/add-edit-fitness-program.component';

@Component({
  selector: 'app-fitness-program-table',
  templateUrl: './fitness-program-table.component.html',
  styleUrls: ['./fitness-program-table.component.css']
})
export class FitnessProgramTableComponent implements AfterViewInit {

  displayedColumns: string[] = ['name', 'description', 'actions'];
  fitnessPrograms!: FitnessTypeViewModel[];
  filterModel: FilterModel = { limit: 5, page: 0, term: "", sortedField: 'Name', sortAsc: true };
  length: number = 100;
  pageSize: number = this.filterModel.limit;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pagedResponse!: PageCollectionResponse;
  pageEvent!: PageEvent;
  

  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort!: MatSort;


  constructor(private fitnessProgramService: FitnessProgramService, public dialog: MatDialog,private _router: Router,
    private toastr: ToastrService,) {
    this.refreshFitnessPrograms(this.filterModel);
  }

  ngAfterViewInit() {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    var filter = { ...this.filterModel };
    filter.term = filterValue;
    this.refreshFitnessPrograms(filter);
  }

  refreshFitnessPrograms(filterModel: FilterModel): void {
    this.fitnessProgramService
      .getPagedFitnessTypes(filterModel)
      .subscribe((res: PageCollectionResponse) => {
        this.fitnessPrograms = res.items;
        this.pagedResponse = res;
      });
  }

  public onPageChange(event: PageEvent): PageEvent {
    var filter = { ...this.filterModel };
    filter.page = event.pageIndex;
    filter.limit = event.pageSize;
    this.refreshFitnessPrograms(filter);
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
      case 'description':
        filter.sortedField = "Description";
        break;
      default: filter.sortedField = "Name";
        break;
    }
    this.refreshFitnessPrograms(filter);
  }
  openDialog(fitnessTypeViewModel?: FitnessTypeViewModel) {
    const dialogConfig = new MatDialogConfig();

    if(fitnessTypeViewModel != null){
      dialogConfig.data = {
          fitnessTypeViewModel: fitnessTypeViewModel
      };
    }
    this.dialog.open(AddEditFitnessProgramComponent, dialogConfig);

  }
  public deleteFitnessProgram = (id: number) => {
      this.fitnessProgramService.deleteFitnessProgram(id).subscribe
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
      this._router.navigate(["/admin/fitnessPrograms"]).then(() => {
        window.location.reload();
      }
      )
    }
  }


