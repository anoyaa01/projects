using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Queries
{
        public class LoginQuery : IRequest<int>  //returns userid
        {
            public string phone { get; set; }
            public string password { get; set; }
        }

    
}
