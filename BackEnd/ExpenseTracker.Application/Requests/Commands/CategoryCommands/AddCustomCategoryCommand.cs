using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.CategoryCommands
{
    public class AddCustomCategoryCommand : IRequest<int>
    {
        public int userId { get; set; }
        public string name { get; set; }
    }
}
