import { FitnessProgramViewModel } from "src/viewModels/fitnessProgramViewModel";

export interface Person {
    firstName: string;
    lastName: string;
    birthdate: Date;
    weight: number;
    height: number;
    gender: string;
    currentFitnessProgram: FitnessProgramViewModel;
    fitnessLevel: string;
}