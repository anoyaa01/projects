using ExpenseTracker.Application.DTOs;
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
       public class GetExpenditureByCategoryOueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetExpenditureByCategoryOuery, List<CategoryExpenditureDTO>>
        {
            private readonly ExpenseTrackerContext _context = context;

            public async Task<List<CategoryExpenditureDTO>> Handle(GetExpenditureByCategoryOuery request, CancellationToken cancellationToken)
            {

                var categoryExpenditures = await _context.Category
                    .Where(c => c.UserId == request.UserId || c.InBuilt)
                    .Select(c => new
                    {
                        Name = c.Name,
                        TotalExpense = _context.Expense
                            .Where(e => e.CategoryId == c.Id)
                            .Sum(e => (double?)e.Amount) ?? 0
                    })
                    .Where(c => c.TotalExpense > 0) // non-zero filter
                    .Select(x => new CategoryExpenditureDTO
                    {
                        Name = x.Name,
                        Expenditure = x.TotalExpense
                    })
                    .ToListAsync(cancellationToken);

                return categoryExpenditures;
            }
        }
 }
