import { Injectable } from "@angular/core";  
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";  
import { Observable } from "rxjs";  
import { FitnessProgramService } from "src/services/fitnessProgram.service";
import { FitnessProgramViewModel } from "src/viewModels/fitnessProgramViewModel";
  
@Injectable()  
export class FitnessProgramResolver implements Resolve<FitnessProgramViewModel> {  
  constructor(private fitnessProgramService: FitnessProgramService) {}  
  
  resolve(route: ActivatedRouteSnapshot): Observable<FitnessProgramViewModel> {  
    let id = route.paramMap.get('id');
    return this.fitnessProgramService.getById(id);  
  }  
}