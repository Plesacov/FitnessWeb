import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { CreateFitnessProgramCommand } from "src/commands/createFitnessProgramCommand";
import { Observable } from "rxjs";
import { UpdateFitnessProgramCommand } from "src/commands/updateFitnessProgramCommand";
import { FitnessProgramViewModel } from "src/viewModels/fitnessProgramViewModel";

@Injectable()
export class FitnessProgramService{
    constructor(private httpService: HttpClient){
    }

    createFitnessProgram(command: CreateFitnessProgramCommand): Observable<any> {
        return this.httpService.post<any>("/api/fitnessPrograms/createNewProgram", command);
    }

    updateFitnessProgram(command: UpdateFitnessProgramCommand): Observable<any> {
        return this.httpService.put<any>("/api/fitnessPrograms/updateNewProgram", command);
    }

    getById(id: number): Observable<FitnessProgramViewModel>{
        return this.httpService.get<FitnessProgramViewModel>(`/api/fitnessPrograms/getById/${id}`);
    }
}