using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands
{
    public class UpdateBudgetCommandHandler:IRequestHandler<UpdateBudgetCommand,int>
    {
        private readonly ExpenseTrackerContext _context;

        public UpdateBudgetCommandHandler(ExpenseTrackerContext Context)
        {
            _context=Context;
        }

        public async Task<int> Handle(UpdateBudgetCommand command, CancellationToken cancellationToken)
        {
            Budget budget=new Budget();
            budget = _context.Budget.FirstOrDefault(x => x.UserId == command.UserId);//&& x.Month == (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)));
            budget.Amount = command.Amount;
            
           
            return await _context.SaveChangesAsync();
        }
    }
}
