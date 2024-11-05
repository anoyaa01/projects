using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.DTOs
{
    public class ExpenseDTO
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateOnly Date { get; set; }
    }
}
