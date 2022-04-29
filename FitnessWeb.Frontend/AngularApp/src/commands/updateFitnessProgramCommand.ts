import { BaseCommand } from "./baseCommandWithId";

export class UpdateFitnessProgramCommand extends BaseCommand{
    name: string;
    description: string;

    constructor(name: string, description: string,id: number){
        super(id);
        this.name = name;
        this.description = description;
    }
}