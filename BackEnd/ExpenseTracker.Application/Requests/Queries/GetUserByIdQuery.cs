using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
    public class GetUserByIdQuery:IRequest<UserDTO>
    {
        public int RequestId { get; set; }
    }
}
