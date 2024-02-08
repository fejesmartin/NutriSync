export class Plan {
    planId: number;
    planName: string;
    description: string;
    calorieIn: number;
    calorieMax: number;

    constructor(planId: number, planName: string, description: string, calorieIn: number, calorieMax: number) {
        this.planId = planId;
        this.planName = planName;
        this.description = description;
        this.calorieIn = calorieIn;
        this.calorieMax = calorieMax;
    }

}