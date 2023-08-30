import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListTasksComponent } from './components/list-tasks/list-tasks.component';
import { UpdateTaskComponent } from './components/update-task/update-task.component';


const routes: Routes = [
  { path:'list-tasks', component:ListTasksComponent },
  { path:'update-task', component:UpdateTaskComponent },
  { path:'update-task/:id', component:UpdateTaskComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
