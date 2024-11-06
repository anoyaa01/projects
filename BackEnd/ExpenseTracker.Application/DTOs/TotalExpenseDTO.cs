using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.DTOs
{
        public class TotalExpenseDTO
        {
            //week month year
            //public int WeeklyExpense { get; set; }
            public double MonthlyExpense { get; set; }
            public double YearlyExpense { get; set; }
            public double RemainingBudget { get; set; }
        }
    

}

