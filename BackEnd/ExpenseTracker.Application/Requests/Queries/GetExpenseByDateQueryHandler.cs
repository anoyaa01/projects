using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
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
            _context=Context;
        }
        public async Task<List<ExpenseDTO>> Handle(GetExpenseByDateQuery request, CancellationToken cancellationToken)
        {
            User requiredUser = _context.User.FirstOrDefault(x => x.Id == request.UserId);

            List<ExpenseDTO> ExpenseList = new List<ExpenseDTO>();

            var query = from expense in _context.Expense
                        join user in _context.User on expense.UserId equals user.Id
                        join category in _context.Category on expense.CategoryId equals category.Id
                        where ((expense.UserId == request.UserId) && (expense.Date>=request.startDate) && (expense.Date<=request.endDate))
                        select new
                        {
                            amount = expense.Amount,
                            date = expense.Date,
                            description = expense.Description,
                            categoryName = category.Name,
                        };

            foreach (var retrieverdExpense in query)
            {
                ExpenseDTO expenseDTO = new ExpenseDTO();
                expenseDTO.Amount = retrieverdExpense.amount;
                expenseDTO.Date = retrieverdExpense.date;
                expenseDTO.Description = retrieverdExpense.description;
                expenseDTO.CategoryName = retrieverdExpense.categoryName;
                ExpenseList.Add(expenseDTO);
            }
            return await Task.FromResult(ExpenseList);
        }
    }
}
