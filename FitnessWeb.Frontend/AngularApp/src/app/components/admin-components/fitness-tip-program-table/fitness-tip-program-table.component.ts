import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { FitnessTipViewModel } from 'src/viewModels/fitnessTipViewModel';
import { FilterModel, PageCollectionResponse } from 'src/viewModels/pageCollectionResponse';
import { AddEditFitnessProgramComponent } from '../add-edit-fitness-program/add-edit-fitness-program.component';

@Component({
  selector: 'app-fitness-tip-program-table',
  templateUrl: './fitness-tip-program-table.component.html',
  styleUrls: ['./fitness-tip-program-table.component.css']
})
export class FitnessTipProgramTableComponent implements AfterViewInit {

  displayedColumns: string[] = ['fitnessProgramName', 'name', 'description', 'actions'];
  fitnessTips!: FitnessTipViewModel[];
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
    this.refreshFitnessTips(this.filterModel);
  }

  ngAfterViewInit() {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    var filter = { ...this.filterModel };
    filter.term = filterValue;
    this.refreshFitnessTips(filter);
  }

  refreshFitnessTips(filterModel: FilterModel): void {
    this.fitnessProgramService
      .getPagedFitnessTips(filterModel)
      .subscribe((res: PageCollectionResponse) => {
        this.fitnessTips = res.items;
        this.pagedResponse = res;
      });
  }

  public onPageChange(event: PageEvent): PageEvent {
    var filter = { ...this.filterModel };
    filter.page = event.pageIndex;
    filter.limit = event.pageSize;
    this.refreshFitnessTips(filter);
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
    this.refreshFitnessTips(filter);
  }
  openDialog(fitnessTipViewModel?: FitnessTipViewModel) {
    const dialogConfig = new MatDialogConfig();

    // if(fitnessTipViewModel != null){
    //   dialogConfig.data = {
    //       fitnessTypeViewModel: fitnessTipViewModel
    //   };
    // }
    // this.dialog.open(AddEditFitnessProgramComponent, dialogConfig);

    //todo: create new dialog for tips

  }
  public deleteFitnessTip = (id: number) => {
      // this.fitnessProgramService.deleteFitnessProgram(id).subscribe
      //   (() => {
      //     this.showSuccess('Deleted successfull');
      //     this.refresh();
      //   },
      //     () => {
      //       this.toastr.error("IT Error");
      //     })

      //todo: delete fitness tip
    }

    showSuccess(message: string) {
      this.toastr.success(`${message}`, 'Success');
    }

    refresh(): void {
      this._router.navigate(["/admin/fitnessTips"]).then(() => {
        window.location.reload();
      }
      )
    }
  }


