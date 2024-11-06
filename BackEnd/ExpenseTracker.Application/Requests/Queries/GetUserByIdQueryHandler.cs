using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain;
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
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery,UserDTO>
    {
        private readonly ExpenseTrackerContext _context;

        public GetUserByIdQueryHandler(ExpenseTrackerContext Context)
        {
            _context = Context;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            User user = await _context.User.FirstOrDefaultAsync(x => x.Id.Equals(request.RequestId));
             UserDTO userDTO = new UserDTO();
                Budget budget =await _context.Budget.FirstOrDefaultAsync(x => (x.UserId.Equals(request.RequestId)) && (x.Month.Month.Equals(DateTime.Now.Month)) && (x.Month.Year.Equals(DateTime.Now.Year)));
                userDTO.Name = user.Name;
                userDTO.PhoneNumber= user.PhoneNumber;
            if (budget == null)
            {
                userDTO.Amount = 0;
            }
            else
            {
                userDTO.Amount = budget.Amount;
            }

            return userDTO;
        }
    }
}
