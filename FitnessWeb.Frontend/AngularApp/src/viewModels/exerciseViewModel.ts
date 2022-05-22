export class ExerciseViewModel {
    id: number;
    name: string;
    countOfRepeats: number;
    videoUrl: string;
    trainingName: string;

    constructor(id: number, name: string, countOfRepeats: number, videoUrl: string, trainingName: string) {
        this.id = id;
        this.name = name;
        this.countOfRepeats = countOfRepeats;
        this.videoUrl = videoUrl;
        this.trainingName = trainingName;
    }
}
