using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;

namespace ExpenseTracker.Application.Requests.Queries
    {
        public class GetTotalExpensesQuery : IRequest<TotalExpenseDTO>
        {
            public int UserId { get; set; }
        }

      
}

