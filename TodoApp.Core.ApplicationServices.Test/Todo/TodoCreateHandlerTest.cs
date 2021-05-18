using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.ApplicationServices.Todos.CommandHandlers;
using TodoApp.Core.Domain.Todos.Commands;
using TodoApp.Core.Domain.Todos.Data;
using Framework.Core.Domain;
using Xunit;
using Framework.Core.Domain.Data;
using Framework.Core.Domain.ApplicationServices;
using TodoApp.Core.ApplicationServices.Test.Fixtures;

namespace TodoApp.Core.ApplicationServices.Test.Todo
{
    [Trait("Category", "CommandHandlers")]
    public class TodoCreateHandlerTest : IClassFixture<ServiceInjectionFixture>
    {
        private ServiceProvider _serviceProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITodoRepository todoRepository;

        public TodoCreateHandlerTest(ServiceInjectionFixture fixture)
        {
            this.unitOfWork = fixture.ServiceProvider.GetService<IUnitOfWork>();
            this.todoRepository = fixture.ServiceProvider.GetService<ITodoRepository>();
        }

        [Fact]
        public void ServiceInjectionTest()
        {
            Assert.NotNull(this.unitOfWork);
            Assert.NotNull(this.todoRepository);
        }
        [Fact]
        public async Task HandleFunctionTest() {
            Create create = 
                new Create() { Text = "test", Title = "title", ValidTo = DateTime.Now.AddDays(1) };
            CreateHandler handler = new CreateHandler(this.unitOfWork,this.todoRepository);
            var result =  await handler.Handle(create);
            Assert.Equal(ApplicationServiceStatus.Ok, result.Status );
            Assert.Equal( 1,result.Data);
        }
    }
}
