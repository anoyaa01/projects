import { CommonModule } from '@angular/common';
import { Component, AfterViewInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Chart } from 'chart.js/auto';

interface IExpense {
  Amount: number | null;
  Description: string | null;
  Category: string | null;
}

@Component({
  selector: 'app-category-expense',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './category-expense.component.html',
  styleUrls: ['./category-expense.component.scss']
})

export class CategoryExpenseComponent implements AfterViewInit {
  expenseList: IExpense[] = [
    { Amount: 100, Description: 'fruits', Category: 'Food' },
    { Amount: 2000, Description: 'Dolo', Category: 'Medical' },
    { Amount: 200, Description: 'shawayi', Category: 'Food' },
    { Amount: 500, Description: 'mandi', Category: 'Food' },
    { Amount: 150, Description: 'petrol', Category: 'Fuel' },
    { Amount: 300, Description: 'clothes', Category: 'Shopping' },
    { Amount: 450, Description: 'electronics', Category: 'Shopping' },
    { Amount: 75, Description: 'stationery', Category: 'Misc' }
  ];

  categoryExpenditure: { [key: string]: number } = {};

  constructor() {
    this.categoryExpenditure = this.groupByCategory(this.expenseList);
  }

  ngAfterViewInit() {
    this.createChart();
    //this.populateTable();
  }

  groupByCategory(expenses: IExpense[]): { [key: string]: number } {
    return expenses.reduce((acc, expense) => {
      if (!acc[expense.Category!]) {
        acc[expense.Category!] = 0;
      }
      acc[expense.Category!] += expense.Amount!;
      return acc;
    }, {} as { [key: string]: number });
  }

  createChart() {
    const labels = Object.keys(this.categoryExpenditure);
    const dataValues = Object.values(this.categoryExpenditure);
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
            position: 'bottom', // Adjust as needed
          },
        },
      }
    });
  }

}
