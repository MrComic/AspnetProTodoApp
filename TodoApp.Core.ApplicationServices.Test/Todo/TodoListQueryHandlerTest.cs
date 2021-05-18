using Framework.Core.Domain.ApplicationServices;
using Framework.Core.Domain.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.ApplicationServices.Test.Fixtures;
using TodoApp.Core.ApplicationServices.Todos.Queries;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Core.Domain.Todos.Queries;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;
using Xunit;

namespace TodoApp.Core.ApplicationServices.Test.Todo
{
    public class TodoListQueryHandlerTest : IClassFixture<ServiceInjectionFixture>
    {
        private readonly ITodoQueryRepository todoRepository;
        private readonly QueryDbContext _context;


        public TodoListQueryHandlerTest(ServiceInjectionFixture fixture)
        {
            this._context = fixture.ServiceProvider.GetService<QueryDbContext>();
            this.todoRepository = fixture.ServiceProvider.GetService<ITodoQueryRepository>();
        }

        [Fact]
        public async Task HandlerTest() {
            
            FakeData.InsertFakeData(this._context,10);
            TodoListQuery request = new TodoListQuery() {
                NeedTotalCount = true,
                PageNumber = 1,
                PageSize = 10,
                SortAscending = true,
                SortBy = "Title"
            };
            TodoListQueryHandler handler = new TodoListQueryHandler(this.todoRepository);

            var result = await handler.Handle(request);
            
            Assert.Equal(ApplicationServiceStatus.Ok, result.Status);
            Assert.Equal(10, result.Data.TotalCount);
            Assert.NotNull(result.Data.QueryResult);
            Assert.NotEmpty(result.Data.QueryResult);
            Assert.Equal("test0", result.Data.QueryResult.FirstOrDefault().Text);
        }
    }
}
