using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            var monthlyBudget = _context.Budget.FirstOrDefault(b => b.UserId == request.UserId
                                                             && b.Month.Month == DateTime.Now.Month
                                                             && b.Month.Year == DateTime.Now.Year);

            //var calendar = CultureInfo.CurrentCulture.Calendar;
            //var currentWeekOfYear = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            //var weeklyTotal = _context.Expense
            //    .Where(e => e.UserId == request.UserId
            //                && e.Date.Year == DateTime.Now.Year)
            //    .AsEnumerable() // above query processes in db
            //    .Where(e => calendar.GetWeekOfYear(e.Date.ToDateTime(TimeOnly.MinValue), CalendarWeekRule.FirstDay, DayOfWeek.Monday) == currentWeekOfYear)
            //    .Sum(e => e.Amount);

            //var today = DateTime.Now;
            //var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            //var endOfWeek = startOfWeek.AddDays(6); // End of week is Sunday      /////changess

            //var weeklyTotal = _context.Expense
            //    .Where(e => e.UserId == request.UserId
            //                && e.Date >= DateOnly.FromDateTime(startOfWeek)
            //                && e.Date <= DateOnly.FromDateTime(endOfWeek))
            //    .Sum(e => e.Amount);


            double remainingBudget = 0;
            if (monthlyBudget != null)
            {
                remainingBudget = monthlyBudget.Amount - monthlyTotal;
            }


            TotalExpenseDTO totalExpenseDTO = new();
            totalExpenseDTO.YearlyExpense = yearlyTotal;
            totalExpenseDTO.MonthlyExpense = monthlyTotal;
            totalExpenseDTO.RemainingBudget = remainingBudget;
            return totalExpenseDTO;
        }
    }

}

