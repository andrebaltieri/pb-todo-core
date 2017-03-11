using System;
using System.Collections.Generic;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Save(Todo.Domain.Entities.Todo todo);
        void Update(Todo.Domain.Entities.Todo todo);
        IEnumerable<Todo.Domain.Entities.Todo> Get();
        Todo.Domain.Entities.Todo Get(Guid id);
    }
}