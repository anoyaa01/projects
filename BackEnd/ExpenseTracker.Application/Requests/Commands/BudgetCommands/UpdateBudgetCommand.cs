using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.BudgetCommands
{
    public class UpdateBudgetCommand : IRequest<int>
    {

        public double Amount { get; set; }
        public int UserId { get; set; }
    }
}
