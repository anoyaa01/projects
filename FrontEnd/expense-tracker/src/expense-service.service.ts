import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExpenseServiceService {
  
   constructor(private http:HttpClient) { }

  submitNewExpense(data:any):any {
      console.log(data)
       this.http.post('http://localhost:5277/api/Expense', data)
      .subscribe({
        next:(value)=>
        {
          console.log(value);
         },
         error:(err)=>
         {
          console.log('error message:',err);
         }
      })
    
  }

}