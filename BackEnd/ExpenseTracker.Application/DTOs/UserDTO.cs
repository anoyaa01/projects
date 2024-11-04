using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public double Amount { get; set; }
    }
}
