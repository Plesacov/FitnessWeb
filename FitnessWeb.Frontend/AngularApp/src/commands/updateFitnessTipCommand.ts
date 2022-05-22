export class UpdateFitnessTipCommand {
    name: string;
    description: string;
    Id: number;

    constructor(name: string, description: string, Id: number) {
        this.name = name;
        this.description = description;
        this.Id = Id;
    }
}