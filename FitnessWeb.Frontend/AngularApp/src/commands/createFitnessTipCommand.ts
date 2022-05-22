export class CreateFitnessTipCommand{
    name: string;
    description: string;
    fitnessProgramId: number;
    
    constructor (name: string, description: string, fitnessProgramId: number){
        this.name = name;
        this.description = description;
        this.fitnessProgramId = fitnessProgramId;

    }
}