using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetCategoriesQuery : IRequest<List<string>>
    {
        public int UserId { get; set; }
    }

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<string>>
    {
        private readonly ExpenseTrackerContext context;

        public GetCategoriesQueryHandler(ExpenseTrackerContext context)
        {
            this.context = context;
        }
        public async Task<List<string>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            Users requiredUser = context.Users.FirstOrDefault(x => x.Id == request.UserId);
            List<string> categoryList = new List<string>();

            var query = from category in context.Category
                        where category.UserId == request.UserId || category.UserId == null
                        select new
                        {
                            categoryName = category.Name,
                        };

            foreach (var retrievedCategory in query)
            {
                
                categoryList.Add(retrievedCategory.categoryName);
            }
            return await Task.FromResult(categoryList);
        }
    }
}
