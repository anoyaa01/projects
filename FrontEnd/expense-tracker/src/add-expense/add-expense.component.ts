import { Component } from '@angular/core';
import { ExpenseServiceService } from '../expense-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IExpenseInterface } from '../i-expense.interface';
import { CategoryServiceService } from '../category-service.service';

@Component({
  selector: 'app-add-expense',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './add-expense.component.html',
  styleUrl: './add-expense.component.scss'
})
export class AddExpenseComponent {
[x: string]: any;

  expenseSubmitted:boolean=false;
  addExpenseDetails!: FormGroup<IExpenseInterface>;
  categoryList:string[] = [];
  UserId:number=3
  Today: Date=new Date();

  constructor(private expenseService: ExpenseServiceService, private categoryService: CategoryServiceService) { }
 
checkCalendar(selectedDate:Date)
{ 
  const Today=new Date();
  
if(this.Today<selectedDate)
{
  alert("Select current date or a past date !!");
}
}
//   today: Date = new Date();
//   dd = (this.today.getDate()).toString();
//    mm = (this.today.getMonth() + 1).toString(); 
//    yyyy = (this.today.getFullYear()).toString();

//  shownDate = (this.yyyy + '-' + this.mm + '-' + this.dd);

  ngOnInit(): void {
    this.addExpenseDetails = new FormGroup<IExpenseInterface>
      ({
        Amount: new FormControl(0, [Validators.required]),
        Description: new FormControl(''),
        Category: new FormControl('', Validators.required),
        Id: new FormControl(this.UserId),
      });

    this.categoryService.getCategoryList(this.UserId).subscribe({
      next: (data) => {
          this.categoryList = data;
          console.log(this.categoryList);
      },
      error: (error) => {
          console.log(error)
      }
    })
  }

  addExpense() {
    this.expenseSubmitted=true;

    if (this.addExpenseDetails.valid) {
      const newExpense =
      {
        Amount: this.addExpenseDetails.value.Amount,
        Description: this.addExpenseDetails.value.Description,
        CategoryName:this.addExpenseDetails.value.Category,
        UserId:this.UserId
      }
      this.expenseService.submitNewExpense(newExpense);
    }
  }
}