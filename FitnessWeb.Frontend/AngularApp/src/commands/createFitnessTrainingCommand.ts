export class CreateFitnessTrainingCommand {
    type: string;
    duration: number;
    fitnessProgramId: number;

    constructor(type: string, duration: number, fitnessProgramId: number) {
        this.type = type;
        this.duration = duration;
        this.fitnessProgramId = fitnessProgramId;

    }
}