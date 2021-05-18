using Framework.Core.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Contracts;
using TodoApp.Core.Domain.Todos.Queries;
using TodoApp.Core.Domain.Todos.QueryModels;

namespace TodoApp.Core.Domain.Todos.Data
{
    public interface ITodoQueryRepository: IQueryRepository
    {
        public Task<PagedData<TodoViewModel>> Select(TodoListQuery request);
    }
}
