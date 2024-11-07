using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetExpenseByDateQueryHandler : IRequestHandler<GetExpenseByDateQuery, List<ExpenseDTO>>
    {
        private readonly ExpenseTrackerContext _context;

        public GetExpenseByDateQueryHandler(ExpenseTrackerContext Context)
        {
            _context = Context;
        }
        public async Task<List<ExpenseDTO>> Handle(GetExpenseByDateQuery request, CancellationToken cancellationToken)
        {

            var expenseList = await (from expense in _context.Expense
                                     join category in _context.Category on expense.CategoryId equals category.Id
                                     where expense.UserId == request.UserId
                                           && expense.Date >= request.startDate
                                           && expense.Date <= request.endDate
                                     select new ExpenseDTO
                                     {
                                         Amount = expense.Amount,
                                         Date = expense.Date,
                                         Description = expense.Description,
                                         CategoryName = category.Name,
                                         Id = expense.Id
                                     }).ToListAsync(cancellationToken);

            return expenseList;

        }
    }
}
