import { ExerciseViewModel } from "./exerciseViewModel";

export class TrainingViewModel {
    id: number;
    type: string;
    exercises: ExerciseViewModel[];
    duration: number;
    fitnessProgramName: string;

    constructor(type: string, exercises: ExerciseViewModel[], duration: number, fitnessProgramName: string, id: number) {
        this.id = id;
        this.type = type;
        this.exercises = exercises;
        this.duration = duration;
        this.fitnessProgramName = fitnessProgramName;
    }

}
