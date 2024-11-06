using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ExpenseTracker.Infrastructure.Repositories;
using System.Reflection.Metadata;
using ExpenseTracker.Domain;

namespace ExpenseTracker.Application.Requests.Commands.UserCommands
{
    public class AddUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
