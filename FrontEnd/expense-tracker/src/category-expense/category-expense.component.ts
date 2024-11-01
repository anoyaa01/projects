import { Component } from '@angular/core';

interface IExpense {
  Amount: number | null;
  Description: string | null;
  Category: string | null;
}

@Component({
  selector: 'app-category-expense',
  standalone: true,
  imports: [],
  templateUrl: './category-expense.component.html',
  styleUrl: './category-expense.component.scss'
})


export class CategoryExpenseComponent {
  expenseList: IExpense[] =[{Amount: 100,
    Description: 'Grocery shopping',
    Category: 'Food'}, {Amount: 2000,
    Description: 'Dolo',
    Category: 'Medical'}
  ]
  
}
