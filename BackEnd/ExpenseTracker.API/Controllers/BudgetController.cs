using ExpenseTracker.Application.Requests.Commands;
using ExpenseTracker.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BudgetController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<int> UpdateBudget(int UserId,Budget budget)
        {
            UpdateBudgetCommand command = new UpdateBudgetCommand();
            command.UserId = UserId;
            return await _mediator.Send(command);
        }
    }
}
