using ExpenseTracker.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetExpenseByDateQuery:IRequest<List<ExpenseDTO>>
    {
        public int UserId { get; set; } 
        public DateOnly startDate { get; set; } 
        public DateOnly endDate { get; set; } 
    }
}
