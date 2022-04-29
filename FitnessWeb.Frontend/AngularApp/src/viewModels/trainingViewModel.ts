export class TrainingViewModel{
    type: string;
    duration: number;

    constructor(duration: number, type: string) {
        this.duration = duration;
        this.type = type;
    }
}