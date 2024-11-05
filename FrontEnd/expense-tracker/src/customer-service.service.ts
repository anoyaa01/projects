import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Route, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  //private SignUpStatus = new Subject<boolean>();
  //SignUpStatus$ = this.SignUpStatus.asObservable(); 
  constructor(private http: HttpClient,private router:Router) { }

  checkUserDetails(data:any): Observable<number> {
    return this.http.post<number>(`http://localhost:5277/api/Users/Login`, data);
  }


  submitNewUser(data: any): any {
     console.log("inside service:");
     console.log(data);
    this.http.post('http://localhost:5277/api/Users', data)
      .subscribe({
        next: (value) => {
          console.log(value);
        //  this.SignUpStatus.next(true);
        },
        error: (err) => {
        //  this.SignUpStatus.next(false);
          console.error('Registration error:', err);
        }
      })
    
  }

}
