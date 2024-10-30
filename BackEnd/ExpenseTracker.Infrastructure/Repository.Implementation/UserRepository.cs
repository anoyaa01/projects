using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Data;
using ExpenseTracker.Infrastructure.Repositories;

namespace ExpenseTracker.Infrastructure.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerContext context;

        public UserRepository(ExpenseTrackerContext context)
        {
            this.context = context;
        }
        public int Add(Users user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }
    }
}
