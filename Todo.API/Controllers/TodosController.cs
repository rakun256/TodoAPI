using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.Todos.Commands.CreateTodo;
using Todo.Application.Features.Todos.Queries.GetAllTodos;
using Todo.Application.Features.Todos.Commands.UpdateTodo;

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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTodosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in URL and body do not match.");

            await _mediator.Send(command);
            return Ok();
        }

        // Bu placeholder, sonradan GetById endpointi geldiğinde çalışır hale gelecek
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(); // Geçici
        }
    }
}
