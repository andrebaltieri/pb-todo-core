using System;
using FluentValidator;

namespace Todo.Domain.Entities
{
    public class Todo
    {
        protected Todo() { }
        public Todo(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            Done = false;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public bool Done { get; private set; }

        public void MarkAsDone() => Done = true;

        public void MarkAsUndone() => Done = false;
    }
}