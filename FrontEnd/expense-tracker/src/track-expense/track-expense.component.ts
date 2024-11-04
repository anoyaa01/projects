// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-track-expense',
//   standalone: true,
//   imports: [],
//   templateUrl: './track-expense.component.html',
//   styleUrl: './track-expense.component.scss'
// })
// export class TrackExpenseComponent {

// }
import { Component } from '@angular/core';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';
import { IExpenseInterface } from '../i-expense.interface';
import { FormGroup } from '@angular/forms';
import { ExpenseServiceService } from '../expense-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [ViewProfileComponent,TrackExpenseComponent,CategoryExpenseComponent,AddExpenseComponent,CommonModule],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})

export class TrackExpenseComponent {

expenseList:any[]=[];
userId:number=1;
constructor(private expenseService: ExpenseServiceService) { }

ngOnInit(): void {
  this.expenseService.getNewExpense(this.userId).subscribe({
    next: (data) => {
      console.log('Fetched expenses:', data); 
      this.expenseList = data; 
    },
    error: (error) => {
      console.error(error);
    }
  })
}
}
