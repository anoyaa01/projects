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
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<string>>
        {
            private readonly ExpenseTrackerContext context;

            public GetCategoriesQueryHandler(ExpenseTrackerContext context)
            {
                this.context = context;
            }
            public async Task<List<string>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                User requiredUser = context.User.FirstOrDefault(x => x.Id == request.UserId);
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
