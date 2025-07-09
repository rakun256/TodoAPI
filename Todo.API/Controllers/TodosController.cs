using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.Todos.Commands.CreateTodo;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        // Bu placeholder, sonradan GetById endpointi geldiğinde çalışır hale gelecek
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(); // Geçici
        }
    }
}
