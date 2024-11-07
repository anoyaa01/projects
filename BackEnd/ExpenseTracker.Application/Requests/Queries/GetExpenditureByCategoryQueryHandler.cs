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

            var categoryExpenditures = await _context.Expense
                .Where(e => e.UserId == request.UserId && e.Date.Month == DateTime.Now.Month)
                .GroupBy(e => e.Category.Name)
                .Select(g => new CategoryExpenditureDTO
                {
                 Name = g.Key,
                 Expenditure = g.Sum(e => e.Amount)
                })
                .Where(dto => dto.Expenditure > 0)
                .ToListAsync(cancellationToken);

            return categoryExpenditures;
            }
        }
 }
