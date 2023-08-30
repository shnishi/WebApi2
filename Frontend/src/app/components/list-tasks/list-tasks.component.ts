import { Component } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { Task } from '../../classes/task'

@Component({
  selector: 'app-list-tasks',
  templateUrl: './list-tasks.component.html',
  styleUrls: ['./list-tasks.component.css']
})
export class ListTasksComponent {

  public taskList:Task[]=[];
  constructor(private taskService:TaskService){}

  ngOnInit() {
    this.taskService.getTasks().subscribe(l => this.taskList = l);
  }

}
