using ExpenseTracker.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private PasswordHasher<string>passwordHasher = new PasswordHasher<string>();
        private string password;
        private int requiredId = 0;
        public async Task<int> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var requiredUser = await _context.User.FirstOrDefaultAsync(x => x.PhoneNumber == request.phone);

            
            if (requiredUser != null)
            {
                var hashStatus = passwordHasher.VerifyHashedPassword(null, requiredUser.Password, request.password);
                if (hashStatus == PasswordVerificationResult.Success) 
                {
                    requiredId = requiredUser.Id;
                }
            }
            

            return await Task.FromResult(requiredId);
        }
    }
}
