using System;

namespace Todo.Domain.Commands
{
    public class RegisterTodoCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}