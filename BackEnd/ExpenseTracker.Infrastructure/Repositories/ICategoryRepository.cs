using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        public Category GetCategories();
    }
}
