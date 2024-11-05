using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
    public class Budget
    {
        public int Id { get; set; }
        public DateOnly Month { get; set; }
        public double Amount { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
    }
}
