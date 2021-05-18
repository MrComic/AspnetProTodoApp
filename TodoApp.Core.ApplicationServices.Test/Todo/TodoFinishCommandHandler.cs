using Framework.Core.Domain.ApplicationServices;
using Framework.Core.Domain.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.ApplicationServices.Test.Fixtures;
using TodoApp.Core.ApplicationServices.Todos.CommandHandlers;
using TodoApp.Core.Domain.Todos.Commands;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Infra.Data.SqlServer;
using Xunit;

namespace TodoApp.Core.ApplicationServices.Test.Todo
{
    public class TodoFinishCommandHandler : IClassFixture<ServiceInjectionFixture>
    {
        private ServiceProvider _serviceProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITodoRepository todoRepository;
        private readonly TodoDbContext _context;


        public TodoFinishCommandHandler(ServiceInjectionFixture fixture)
        {
            this._context = fixture.ServiceProvider.GetService<TodoDbContext>();
            this.unitOfWork = fixture.ServiceProvider.GetService<IUnitOfWork>();
            this.todoRepository = fixture.ServiceProvider.GetService<ITodoRepository>();
        }

        [Fact]
        public async Task HandleFunctionTest()
        {

            FakeData.InsertFakeData(this._context,3);
            var request = new TodoFinished() { Id = 2 };


            FinishTodoHandler handler= 
                new FinishTodoHandler(this.unitOfWork, this.todoRepository);
            var result = await handler.Handle(request);


            Assert.Equal(ApplicationServiceStatus.Ok, result.Status);
        }
    }
}
