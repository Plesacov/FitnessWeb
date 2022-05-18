export class AssignFitnessProgramCommand{
fitnessTypeId: number;
userId: number;
fitnessLevel: string;

constructor(fitnessTypeId: number, userId: number, fitnessLevel: string){
    this.fitnessTypeId = fitnessTypeId;
    this.userId = userId;
    this.fitnessLevel = fitnessLevel;
}
}