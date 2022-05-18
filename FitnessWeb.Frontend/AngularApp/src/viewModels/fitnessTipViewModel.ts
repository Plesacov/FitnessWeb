export class FitnessTipViewModel{
    name: string;
    description: string;
    fitnessProgramName: string;
    id: number;

    constructor (name: string, description: string, fitnessProgramName: string, id: number){
        this.name = name;
        this.description = description;
        this.fitnessProgramName = fitnessProgramName;
        this.id = id;
    }
}