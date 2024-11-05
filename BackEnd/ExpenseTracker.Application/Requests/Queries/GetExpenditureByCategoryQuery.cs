using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Application.Requests.Queries
 {
        public class GetExpenditureByCategoryOuery : IRequest<List<CategoryExpenditureDTO>>
        {
            public int UserId { get; set; }
        }

}
