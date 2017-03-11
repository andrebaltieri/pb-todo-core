using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDataContext _context;

        public TodoRepository(TodoDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Entities.Todo> Get()
        {
            return _context.Todos.ToList();
        }

        public Domain.Entities.Todo Get(Guid id)
        {
            return _context.Todos.Find(id);
        }

        public void Save(Domain.Entities.Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}