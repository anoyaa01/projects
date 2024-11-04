using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Requests.Commands.UserCommands;
using ExpenseTracker.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> AddUser(AddUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<UserDTO> GetUser(int Id)
        {
            GetUserByIdQuery query = new GetUserByIdQuery();
            query.RequestId = Id;
            return await _mediator.Send(query);
        }
    }
}
