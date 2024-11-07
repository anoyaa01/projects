import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Chart } from 'chart.js/auto';
import { CategoryServiceService } from '../category-service.service';
import { RouterModule } from '@angular/router';
import { UserIdService } from '../user-id.service';

interface ICategory {
  name: string;
  expenditure: number;
}


@Component({
  selector: 'app-category-expense',
  standalone: true,
  imports: [FormsModule, CommonModule,RouterModule],
  templateUrl: './category-expense.component.html',
  styleUrls: ['./category-expense.component.scss']
})

export class CategoryExpenseComponent  {

  userId:number = 1;
  categoryList:ICategory[]=[];

  constructor(private categoryService : CategoryServiceService,private UserIdService:UserIdService) {
    
  }

  ngOnInit(): void {
    this.userId=this.UserIdService.userId;
    console.log("userid in catexp",this.userId);
    this.categoryService.getExpenditureByCategory(this.userId).subscribe({
      next: (data) => {
        this.categoryList = data; 
        console.log('Fetched categories:',this.categoryList);
        if(this.categoryList.length==0){
          alert("No expenses in Current Month.")
        }
        this.createChart();
      },
      error: (error) => {
        console.error(error);
      }
    })
  }
  



  createChart() {
    const labels = this.categoryList.map(x => x.name);
    const dataValues = this.categoryList.map(x => x.expenditure);
    const backgroundColors = ["#fd7f6f", "#7eb0d5", "#b2e061", "#bd7ebe", "#ffb55a", "#ffee65", "#beb9db", "#fdcce5", "#8bd3c7"]

    const expenseChart = document.getElementById("chartjs-expense-pie") as HTMLCanvasElement;

    new Chart(expenseChart, {
      type: "pie",
      data: {
        labels: labels,
        datasets: [{
          data: dataValues,
          backgroundColor: backgroundColors,
          borderWidth: 2
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: 'bottom',
          },
        },
      }
    });
  }

}