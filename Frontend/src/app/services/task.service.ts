import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Task } from '../classes/task';
import { Observable, catchError, of } from 'rxjs';
import { Router } from '@angular/router'


@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'http://localhost:8080/api';  // URL to web api
  private httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient, private router: Router) { }

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl + '/Tasks')
      .pipe(catchError(this.handleError<Task[]>('getTask', [])));

  }

  getTask(tid: number): Observable<Task> {
    return this.http.get<Task>(this.apiUrl + '/Tasks/'+tid)
      .pipe(catchError(this.handleError<Task>('getTask', undefined)));

  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.router.navigate(['Tasks']);
      console.error('handleError ' + error.error.responseType + '-' + error.error.text); // log to console instead
      return of(result as T);
    };
  }

  createTask(task: Task): Observable<Task> {
    return this.http.post<Task>(this.apiUrl + '/Tasks', task, { headers: this.httpHeaders })
  }

  updateTask(task: Task): Observable<Task> {
    return this.http.put<Task>(this.apiUrl + '/Tasks/' + task.taskId, task, { headers: this.httpHeaders })
  }

  
}
