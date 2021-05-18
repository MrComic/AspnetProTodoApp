using Framework.Core.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.QueryModels;

namespace TodoApp.Core.Domain.Todos.Queries
{
    public class TodoListQuery : PageQuery<PagedData<TodoViewModel>>, ITodoListQuery
    {
    }
}
