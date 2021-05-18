using Framework.Core.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Core.Domain.Todos.Queries;
using TodoApp.Core.Domain.Todos.QueryModels;
using TodoApp.Infra.Data.SqlServer.Queries.Contracts;
using TodoApp.Infra.Data.SqlServer.ExtentionMethods;
using TodoApp.Infra.Data.SqlServer.Queries.Todo.Entities;
namespace TodoApp.Infra.Data.SqlServer.Queries.Todo
{
    public class TodoQueryRepository : BaseQueryRepository<QueryDbContext>, ITodoQueryRepository
    {
        public TodoQueryRepository(QueryDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<PagedData<TodoViewModel>> Select(TodoListQuery request)
        {
            var query = _dbContext.Todos
                .Select(p => new TodoViewModel() { Done =p.Done,Text = p.Text,Title= p.Text,ValidTo=p.ValidTo });
           return await PageQuery(query, request);
        }

    }
}
