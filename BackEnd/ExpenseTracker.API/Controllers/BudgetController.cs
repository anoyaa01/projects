using ExpenseTracker.Application.Requests.Commands.BudgetCommands;
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
        public async Task<int> UpdateBudget([FromBody] UpdateBudgetCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
