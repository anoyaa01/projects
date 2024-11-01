using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }

    //public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    //{
    //    private readonly ExpenseTrackerContext context;

    //    public GetCategoriesQueryHandler(ExpenseTrackerContext context)
    //    {
    //        this.context = context;
    //    }

    //    public Task<int> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    //    {
    //        List<Category> result = new List<Category>();
            

    //    }
    //}
}
