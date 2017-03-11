using System;

namespace Todo.Domain.Commands
{
    public class MarkTodoCommand : ICommand
    {
        public Guid Id { get; set; }
        public bool Done { get; set; }
    }
}