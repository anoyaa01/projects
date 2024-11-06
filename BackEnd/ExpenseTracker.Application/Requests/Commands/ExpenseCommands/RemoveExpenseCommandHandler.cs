using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.ExpenseCommands
{
    public class RemoveExpenseCommandHandler(ExpenseTrackerContext Context) : IRequestHandler<RemoveExpenseCommand, int>
    {
        private readonly ExpenseTrackerContext _context = Context;

        public async Task<int> Handle(RemoveExpenseCommand command, CancellationToken cancellationToken)
        {
            Expense expense = await _context.Expense.FirstOrDefaultAsync(x => x.UserId == command.UserId && x.Id == command.ExpenseId);
            _context.Expense.Remove(expense);
            _context.SaveChanges();

            return 0;
        }
    }
}
