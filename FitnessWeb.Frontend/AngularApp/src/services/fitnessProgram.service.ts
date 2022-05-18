import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { UpdateFitnessProgramCommand } from "src/commands/updateFitnessProgramCommand";
import { FitnessProgramViewModel } from "src/viewModels/fitnessProgramViewModel";
import { AssignFitnessProgramCommand } from "src/commands/assignFitnessProgramCommand";
import { CreateFitnessProgramCommand } from "src/commands/createFitnessProgramCommand";
import { FitnessTypeViewModel } from "src/viewModels/fitnessTypeViewModel";
import { FilterModel, PageCollectionResponse } from "src/viewModels/pageCollectionResponse";
import { DeleteFitnessProgramCommand } from "src/commands/deleteFitnessProgramCommand";

@Injectable()
export class FitnessProgramService{
    constructor(private httpService: HttpClient){
    }

    createFitnessProgram(command: CreateFitnessProgramCommand): Observable<any> {
        return this.httpService.post<any>("/api/fitnessPrograms/createNewProgram", command);
    }

    updateFitnessProgram(command: UpdateFitnessProgramCommand): Observable<any> {
        return this.httpService.put<any>("/api/fitnessPrograms/updateFitnessProgram", command);
    }

    deleteFitnessProgram(id: number): Observable<any> {
        return this.httpService.delete<any>(`/api/fitnessPrograms/deleteFitnessProgram/${id}`);
    }

    getById(id: any): Observable<FitnessProgramViewModel>{
        return this.httpService.get<FitnessProgramViewModel>(`/api/fitnessPrograms/getById/${id}`);
    }

    assignFitnessProgram(command: AssignFitnessProgramCommand): Observable<any> {
        return this.httpService.post<any>("api/fitnessPrograms/getFitnessProgram", command);
    }

    getAllFitnessTypes(): Observable<FitnessTypeViewModel[]> {
        return this.httpService.get<FitnessTypeViewModel[]>("api/fitnessPrograms/getAllFitnessTypes");
    }

    getPagedFitnessTypes(filterModel: FilterModel): Observable<PageCollectionResponse> {
        return this.httpService.post<PageCollectionResponse>("api/fitnessPrograms/paginatedFitnessTypes", filterModel);
    }

    getPagedFitnessTips(filterModel: FilterModel): Observable<PageCollectionResponse> {
        return this.httpService.post<PageCollectionResponse>("api/fitnessPrograms/paginatedFitnessTips", filterModel);
    }
}