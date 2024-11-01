using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.DTOs
{
    public class ExpenseDTO
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
