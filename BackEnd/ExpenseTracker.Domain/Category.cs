using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InBuilt { get; set; }
        public int? UserId   { get; set; }
        public Users? User { get; set; }
    }
}
