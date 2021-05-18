using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Contracts;
using TodoApp.Core.Domain.Todos.Entities;

namespace TodoApp.Core.Domain.Todos.Data
{
    public interface ITodoRepository : ICommandRepository<Todo>
    {
    }
}
