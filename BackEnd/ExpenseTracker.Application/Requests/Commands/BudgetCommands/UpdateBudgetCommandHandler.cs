using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.BudgetCommands
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, int>
    {
        private readonly ExpenseTrackerContext _context;

        public UpdateBudgetCommandHandler(ExpenseTrackerContext Context)
        {
            _context = Context;
        }

        public async Task<int> Handle(UpdateBudgetCommand command, CancellationToken cancellationToken)
        {
            Budget budget = new Budget();
            budget = await _context.Budget.FirstOrDefaultAsync(x => x.UserId == command.UserId && x.Month.Month.Equals(DateTime.Now.Month) && x.Month.Year.Equals(DateTime.Now.Year));

            if (budget == null)
            {
                Budget newBudget = new Budget();
                newBudget.Amount = command.Amount;
                newBudget.Month = DateOnly.FromDateTime(DateTime.Now);
                newBudget.UserId = command.UserId;
                _context.Budget.Add(newBudget);
            }
            else
            {
                budget.Amount = command.Amount;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
