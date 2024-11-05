using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Requests.Commands.ExpenseCommands;
using ExpenseTracker.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IMediator mediator;

        public ExpenseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ExpenseDTO>> GetExpensesByUserId(int id)
        {
            GetExpenseQuery query = new GetExpenseQuery();
            query.UserId = id;
            return await mediator.Send(query);
        }

        [HttpGet("ExpenseByDate")]
        public async Task<List<ExpenseDTO>> GetExpenseByDate(int id,DateOnly startDate,DateOnly endDate)
        {
            GetExpenseByDateQuery query = new GetExpenseByDateQuery();
            query.UserId=id;
            query.endDate = endDate;
            query.startDate = startDate;
            return await mediator.Send(query);
        }


        [HttpGet("TotalByDate")]
        public async Task<TotalExpenseDTO> GetTotalExpensesByDate(int id)
        {
            GetTotalExpensesQuery query = new GetTotalExpensesQuery();
            query.UserId = id;
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> AddNewExpense(AddExpenseCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
