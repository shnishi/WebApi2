export class Task {
    taskId: number;
    title: string;
    createdAt: string;
    userId: number;
    isActive: boolean;

    constructor(id:number, t:string, ca:string, userId:number, ia:boolean){
        this.taskId=id;
        this.title=t;
        this.createdAt=ca;
        this.userId=userId;
        this.isActive=ia;

    }

}
