export class CreateFitnessExerciseCommand {
    name: string;
    countOfRepeats: number;
    videoUrl: string;
    fitnessTrainingId: number;

    constructor(name: string, countOfRepeats: number, videoUrl: string, fitnessTrainingId: number) {
        this.name = name;
        this.countOfRepeats = countOfRepeats;
        this.videoUrl = videoUrl;
        this.fitnessTrainingId = fitnessTrainingId;
    }
}
