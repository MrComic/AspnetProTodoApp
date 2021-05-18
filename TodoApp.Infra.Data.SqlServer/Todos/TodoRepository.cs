using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Core.Domain.Todos.Entities;

namespace TodoApp.Infra.Data.SqlServer.Todos
{
    public class TodoRepository : BaseCommandRepository<Todo, TodoDbContext>, ITodoRepository
    {
        public TodoRepository(TodoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
