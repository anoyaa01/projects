using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.ExpenseCommands
{
    public class RemoveExpenseCommand : IRequest<int>
    {
        public int ExpenseId { get; set; }
        public int UserId { get; set; }
    }
}
