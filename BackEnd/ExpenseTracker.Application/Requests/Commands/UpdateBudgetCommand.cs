using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands
{
    public class UpdateBudgetCommand:IRequest<int>
    {
        public string Month { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
    }
}
