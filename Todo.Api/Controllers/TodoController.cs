using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        private readonly TodoHandler _handler;

        public TodoController(ITodoRepository repository, TodoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/todos")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpPost]
        [Route("v1/todos")]
        public IActionResult Post([FromBody]RegisterTodoCommand command)
        {
            command.Validate();
                        
            if (!command.IsValid())
                return BadRequest(command.Notifications);

            var result = _handler.Handle(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("v1/todos/{id}")]
        public IActionResult Put(Guid id, [FromBody]MarkTodoCommand command)
        {
            command.Id = id;
            
            var result = _handler.Handle(command);
            return Ok(result);
        }
    }
}