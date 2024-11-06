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
    public class GetCategoriesQuery : IRequest<List<CategoryDTO>>
    {
        public int UserId { get; set; }
    }
}
