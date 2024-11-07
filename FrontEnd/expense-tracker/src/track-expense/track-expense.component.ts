import { Component } from '@angular/core';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';
import { ExpenseServiceService } from '../expense-service.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserIdService } from '../user-id.service';


interface ExpenseList {
  id:number;
  description: string;
  amount: number;
  categoryName: string;
  date: Date; 
}

interface TotalExpenseList{  /////////////changes
  yearlyExpense: number;
  monthlyExpense: number;
  remainingBudget: number;
}

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [ViewProfileComponent,TrackExpenseComponent,CategoryExpenseComponent,AddExpenseComponent,CommonModule,RouterModule],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})

export class TrackExpenseComponent {

expenseList:ExpenseList[]=[];
expenseFilterList:ExpenseList[]=[];
userId:number=1;
today = new Date();
startDate : Date=new Date();
endDate :Date=new Date();
filter: boolean=false;
totalExpenseList: TotalExpenseList[]=[]; /////////////changes
totalAmount:number=0;
totalAmountFiltered:number=0; 
monthCheck = new Date();

constructor(private expenseService: ExpenseServiceService,private UserIdService:UserIdService) { }

ngOnInit(): void {
  this.monthCheck.setDate(this.today.getDate() - 30);
  this.monthCheck.setHours(0, 0, 0, 0);
  this.userId=this.UserIdService.userId;
 this.filter=false;
  this.expenseService.getNewExpense(this.userId).subscribe({
    next: (data) => {
      console.log('initially Fetched expenses:', data); 
      this.expenseList = data; 
      this.totalAmount = this.expenseList.reduce((sum, expense) => sum + expense.amount, 0);

    },
    error: (error) => {
      console.log(error);
    }
  })

  this.expenseService.getTotalExpense(this.userId).subscribe({
    next: (data) => {
      console.log('initially Fetched total(yearly,weekly) expenses:', data); 
     this.totalExpenseList = [data]; 
    },
    error: (error) => {
      console.log(error);
    }
  })
  
}

onSelectStart(event:Event)
{
  const inputStartDate = event.target as HTMLInputElement;
    const selectedStartDate = inputStartDate.value;
    const selectedStartDateObj = new Date(selectedStartDate);

    if (selectedStartDateObj> this.today) {
      alert("Select current date or a past date!!");
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

}

applyFilter()
{
  this.filter=true;
  this.expenseService.getFilterExpense(this.userId,this.startDate,this.endDate).subscribe({
  next: (data) => {
    console.log(this.userId,this.startDate,this.endDate);
    console.log('Fetched expenses after filter:', data); 
    this.expenseFilterList = data; 
    this.totalAmountFiltered = this.expenseFilterList.reduce((sum, expense) => sum + expense.amount, 0);
  },
  error: (error) => {
    console.log(error);
  }
})
}


removeFilter(){
  this.filter=false   //////changes
}

onDelete(index : number) 
{
  const expenseDate = new Date(this.expenseList[index].date);
  expenseDate.setHours(0, 0, 0, 0);
  if(expenseDate > this.monthCheck)
{
 alert("Your selected expense is getting Deleted !!");
 console.log(this.expenseList[index].id);
  this.expenseService.removeExpense(this.userId,this.expenseList[index].id).subscribe({
    next:()=>
    {
      console.log(" delete successfully connected");
      this.totalAmount-=this.expenseList[index].amount;
      this.expenseList.splice(index, 1);
      this.expenseService.getTotalExpense(this.userId).subscribe({   //////changes
        next: (data) => {
          console.log('initially Fetched total(yearly,weekly) expenses:', data); 
         this.totalExpenseList = [data]; 
        },
        error: (error) => {
          console.log(error);
        }
      })
    },
  error: (error) => {
    console.log(error);
  }
})
}
else{
  //console.log("DATES  : ",this.expenseList[index].date,"/////// ",this.monthCheck)
  alert("Only Previous month expense can be deleted !")
}
}

onFilterDelete(index : number) 
{
  const expenseDate = new Date(this.expenseList[index].date);
  expenseDate.setHours(0, 0, 0, 0);
  if(expenseDate > this.monthCheck)
  {
 alert("Your selected expense is getting Deleted !!");
 console.log(this.expenseFilterList[index].id);
  this.expenseService.removeExpense(this.userId,this.expenseFilterList[index].id).subscribe({
    next:()=>
    {
      console.log(" delete successfully connected");
      this.totalAmountFiltered-=this.expenseFilterList[index].amount;
      this.expenseFilterList.splice(index, 1);
      this.expenseService.getTotalExpense(this.userId).subscribe({   //////changes
        next: (data) => {
          console.log('initially Fetched total(yearly,weekly) expenses:', data); 
         this.totalExpenseList = [data]; 
        },
        error: (error) => {
          console.log(error);
        }
      })
    },
  error: (error) => {
    console.log(error);
  }
})
}
else{
  alert("Only Previous month expense can be deleted !")
}
}
}


