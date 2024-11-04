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

            Users user = _context.Users.FirstOrDefault(x => x.Id.Equals(request.RequestId));
             UserDTO userDTO = new UserDTO();
                Budget budget = _context.Budget.FirstOrDefault(x => x.UserId.Equals(request.RequestId));
                userDTO.Name = user.Name;
                userDTO.PhoneNumber= user.PhoneNumber;  
                userDTO.Amount= budget.Amount;

            return await Task.FromResult(userDTO);
        }
    }
}
