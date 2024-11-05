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
expenseFilterList:any[]=[];
userId:number=1;
today = new Date();
startDate : Date=new Date();
endDate :Date=new Date();
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

onSelectStart(event:Event)
{
  const inputStartDate = event.target as HTMLInputElement;
    const selectedStartDate = inputStartDate.value;
    const selectedStartDateObj = new Date(selectedStartDate);
    // const startDateWithoutTime = new Date(selectedStartDateObj.setHours(0, 0, 0, 0));
    // const todayWithoutTime = new Date(this.today.setHours(0, 0, 0, 0));
    
    // if (startDateWithoutTime > todayWithoutTime) {
    //   alert("Select current date or a past date!");
    // }
    if (selectedStartDateObj > this.today) {
      alert("Select current date or a past date !!");
    }
this.startDate=selectedStartDateObj;

}

onSelectEnd(event:Event)
{
  const inputEndDate = event.target as HTMLInputElement;
  const selectedEndDate = inputEndDate.value;
  const selectedEndDateObj = new Date(selectedEndDate);

  if(selectedEndDateObj>this.today)
  {
    alert("Select a current or past date !");
  }
  this.endDate=selectedEndDateObj;
  this.onFilter();
}

onFilter()
{
  this.expenseService.getFilterExpense(this.userId,this.endDate,this.startDate).subscribe({
  next: (data) => {
    console.log('Fetched expenses:', data); 
    this.expenseFilterList = data; 
  },
  error: (error) => {
    console.error(error);
  }
})

}
}


