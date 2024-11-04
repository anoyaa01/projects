using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<string>> GetCategoriesByUserId(int id)
        {
            GetCategoriesQuery query = new GetCategoriesQuery();
            query.UserId = id;
            return await mediator.Send(query);
        }
    }
}
