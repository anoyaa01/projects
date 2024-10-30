using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
 
    public class Expense
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; } 
        public  Users User { get; set; }

        public int CategoryId {  get; set; }    
        public Category Category { get; set; }
       
    }
}
