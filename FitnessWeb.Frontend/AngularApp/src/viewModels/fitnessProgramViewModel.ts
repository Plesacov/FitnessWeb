import { FitnessTipViewModel } from "./fitnessTipViewModel";
import { FitnessTypeViewModel } from "./fitnessTypeViewModel";
import { TrainingViewModel } from "./trainingViewModel";

export class FitnessProgramViewModel {
    id: number;
    type: FitnessTypeViewModel;
    trainings: TrainingViewModel[];
    fitnessTips: FitnessTipViewModel[];

    constructor(id: number, type: FitnessTypeViewModel, trainings: TrainingViewModel[], fitnessTips: FitnessTipViewModel[]) {
        this.id = id;
        this.type = type;
        this.trainings = trainings;
        this.fitnessTips = fitnessTips;
    }
}