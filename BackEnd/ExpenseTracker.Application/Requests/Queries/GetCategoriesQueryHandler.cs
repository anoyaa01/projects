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
    public class GetCategoriesQueryHandler(ExpenseTrackerContext context) : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly ExpenseTrackerContext _context = context;

        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<string> categoryList = new List<string>();

            var query = from category in _context.Category
                        where category.UserId == request.UserId || category.UserId == null
                        select new CategoryDTO()
                        {
                            Name = category.Name,
                        };
            var data = query.ToListAsync(cancellationToken);


            return await data;
        }
    }


}
