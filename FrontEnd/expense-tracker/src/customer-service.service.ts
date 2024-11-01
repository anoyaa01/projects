import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {
  //private SignUpStatus = new Subject<boolean>();
  //SignUpStatus$ = this.SignUpStatus.asObservable();
  constructor(private http: HttpClient) { }

  submitNewUser(data: any): any {
    // console.log("inside service");
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
