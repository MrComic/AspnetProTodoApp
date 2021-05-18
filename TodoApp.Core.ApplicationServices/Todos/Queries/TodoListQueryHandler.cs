using Framework.Core.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Core.Domain.Todos.Queries;
using TodoApp.Core.Domain.Todos.QueryModels;
using TodoApp.Infra.Data.SqlServer.Queries.Todo;

namespace TodoApp.Core.ApplicationServices.Todos.Queries
{
    public class TodoListQueryHandler : QueryHandler<TodoListQuery, PagedData<TodoViewModel>>
    {
        private readonly ITodoQueryRepository _repository;

        public TodoListQueryHandler(ITodoQueryRepository repository)
        {
            this._repository = repository;      
        }

        public override async Task<QueryResult<PagedData<TodoViewModel>>> Handle(TodoListQuery request)
        {
            var res = await _repository.Select(request);
            return await ResultAsync(res);
        }
    }
}
