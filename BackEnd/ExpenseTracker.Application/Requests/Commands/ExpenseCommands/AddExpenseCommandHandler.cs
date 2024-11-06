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
    public class AddExpenseCommandHandler(ExpenseTrackerContext Context) : IRequestHandler<AddExpenseCommand, int>
    {
        private readonly ExpenseTrackerContext _context = Context;

        public async Task<int> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense expense = new Expense();

            expense.User = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId);
            expense.Date = request.Date;
            expense.Description = string.IsNullOrEmpty(request.Description) ? "No description provided" : request.Description;
            expense.Amount = request.Amount;

            var categories = _context.Category.Where(x => x.InBuilt == true || x.UserId == request.UserId);
            expense.Category =await  categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);


            _context.Add(expense);

            return await _context.SaveChangesAsync();
        }
    }
}