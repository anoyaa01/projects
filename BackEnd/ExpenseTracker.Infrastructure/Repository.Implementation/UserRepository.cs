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
        private readonly ExpenseTrackerContext _context;

        public UserRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public int AddUser(Users user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }
    }
}
