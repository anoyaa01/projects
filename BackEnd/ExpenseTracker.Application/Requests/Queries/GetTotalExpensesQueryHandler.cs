using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetTotalExpensesQueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetTotalExpensesQuery, TotalExpenseDTO>
        {
            private readonly ExpenseTrackerContext _context = context;

            public async Task<TotalExpenseDTO> Handle(GetTotalExpensesQuery request, CancellationToken cancellationToken)
            {
                var monthlyTotal = _context.Expense.Where(e => e.UserId == request.UserId
                                                          && e.Date.Month == DateTime.Now.Month
                                                          && e.Date.Year == DateTime.Now.Year)
                                                    .Sum(e => e.Amount);

                var yearlyTotal = _context.Expense.Where(e => e.UserId == request.UserId
                                                          && e.Date.Year == DateTime.Now.Year)
                                                    .Sum(e => e.Amount);

                //CultureInfo myCI = new CultureInfo("en-US");
                //Calendar myCal = myCI.Calendar;

                //var currentWeek = myCal.GetWeekOfYear;

                TotalExpenseDTO totalExpenseDTO = new();
                totalExpenseDTO.YearlyExpense = yearlyTotal;
                totalExpenseDTO.MonthlyExpense = monthlyTotal;
                return await Task.FromResult(totalExpenseDTO);
            }
    }

}

