export class UpdateFitnessTrainingCommand {
    type: string;
    duration: number;
    id: number;

    constructor(type: string, duration: number, id: number) {
        this.type = type;
        this.duration = duration;
        this.id = id;

    }
}