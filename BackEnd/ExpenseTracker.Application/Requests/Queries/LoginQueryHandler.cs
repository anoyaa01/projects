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
        public class LoginQueryHandler(ExpenseTrackerContext context) : IRequestHandler<LoginQuery, int>
        {
            private readonly ExpenseTrackerContext _context = context;

            public async Task<int> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                var requiredUser =await _context.User.FirstOrDefaultAsync(x => x.PhoneNumber == request.phone
                                                                      && x.Password == request.password);
                if (requiredUser == null)
                {
                    return 0;
                }

                return await Task.FromResult(requiredUser.Id);
            }
        }
}
