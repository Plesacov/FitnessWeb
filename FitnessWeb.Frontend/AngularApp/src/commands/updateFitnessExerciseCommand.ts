export class UpdateFitnessExerciseCommand {
    id: number;
    name: string;
    countOfRepeats: number;
    videoUrl: string;

    constructor(id: number, name: string, countOfRepeats: number, videoUrl: string) {
        this.id = id;
        this.name = name;
        this.countOfRepeats = countOfRepeats;
        this.videoUrl = videoUrl;
    }
}
