export class FitnessTypeViewModel{
    id: number;
    name: string;
    description: string;

    constructor (name: string, description: string,id: number){
        this.name = name;
        this.description = description;
        this.id = id;
    }
}