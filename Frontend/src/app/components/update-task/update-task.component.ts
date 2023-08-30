import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';
import { Task } from 'src/app/classes/task';
import { formatDate } from '@angular/common';


enum Mode { Update, Read, Add}

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent {
  public task:Task;
  public mode : Mode = Mode.Read;

  constructor(private taskService:TaskService, private router: Router, private activatedRoute: ActivatedRoute){
    this.task=new Task(0, '', new Date().toISOString().toString(), 0 , true);
    this.loadData();

  }

  loadData(){
    this.activatedRoute.params.subscribe( params => {
      let tid=params['id'];
      if(tid) {
        this.taskService.getTask(tid).subscribe(t => this.task=t);
        this.mode=Mode.Update;
      }
      else {
        this.mode=Mode.Add;
      }
    })
  }


  updateTask(){
    this.taskService.updateTask(this.task).subscribe(
      (t) => {
        this.task=t;
        console.log(this.task);
        this.router.navigate(['/list-tasks']);
      }
    )

  }

  addTask(){
    this.taskService.createTask(this.task).subscribe(
      (t) => {
        this.task=t;
        console.log(this.task);
        this.router.navigate(['/list-tasks']);
      }
    )
  }

  saveTask(){
    if(this.mode==Mode.Add) {
      this.addTask();
    } 
    else if(this.mode==Mode.Update){
      this.updateTask();
    }
  }

  fDate(dt: any): string {
    return formatDate(dt, 'yyyy-MM-dd', 'en-US');
  }

}
