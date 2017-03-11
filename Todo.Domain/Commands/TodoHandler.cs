using System;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands
{
    public class TodoHandler :
        ICommandHandler<RegisterTodoCommand>,
        ICommandHandler<MarkTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterTodoCommand command)
        {
            // Gerar a tarefa
            var todo = new Todo.Domain.Entities.Todo(command.Title);

            // Incluir no banco
            _repository.Save(todo);

            return new RegisterTodoCommandResult
            {
                Id = todo.Id,
                Title = todo.Title
            };
        }

        public ICommandResult Handle(MarkTodoCommand command)
        {
            // Obter o todo
            var todo = _repository.Get(command.Id);

            // Altera o status
            if (command.Done)
                todo.MarkAsDone();
            else
                todo.MarkAsUndone();

            // Salvar no banco
            _repository.Update(todo);

            return new RegisterTodoCommandResult
            {
                Id = todo.Id,
                Title = todo.Title,
                Done = todo.Done
            };
        }
    }
}