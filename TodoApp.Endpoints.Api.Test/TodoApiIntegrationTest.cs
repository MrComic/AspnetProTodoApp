using Framework.Core.Domain.ApplicationServices;
using Framework.Core.Domain.Queries;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.QueryModels;
using TodoApp.Endpoints.Api.Test.Fixtures;
using Xunit;
namespace TodoApp.Endpoints.Api.Test
{
    public class TodoApiIntegrationTest: IntegrationTest
    {
        public TodoApiIntegrationTest(ApiFixture fixture):base(fixture) { }

        [Fact]
        public async Task CreateTodoTest()
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new TodoApp.Core.Domain.Todos.Commands.Create() { 
                    Text = "testText",
                    Title = "TestTitle",
                    ValidTo = DateTime.Now.AddDays(10)
                }),
            Encoding.UTF8,
            "application/json");

            var response = await _client.PostAsync("/api/Todo/", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var id = JsonConvert.DeserializeObject<long>(
                  await response.Content.ReadAsStringAsync()
            );
            Assert.True(id > 10);
        }

        [Fact]
        public async Task TodoListTest() 
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new TodoApp.Core.Domain.Todos.Queries.TodoListQuery()
                {
                    PageSize = 10,
                    NeedTotalCount = true,
                    PageNumber = 1,
                    SortAscending = true,
                    SortBy = "Title"
                }),
            Encoding.UTF8,
            "application/json"); 

            var response = await _client.PostAsync("/api/Todo/List",content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode );

            var todos = JsonConvert.DeserializeObject< PagedData<TodoViewModel>>(
                  await response.Content.ReadAsStringAsync()
            );
            Assert.Equal(10, todos.TotalCount);
        }

        [Fact]
        public async Task FinishTodoTest()
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(new TodoApp.Core.Domain.Todos.Commands.TodoFinished()
                {
                    Id = 1
                }),
            Encoding.UTF8,
            "application/json");

            var response = await _client.PutAsync("/api/Todo/Finish", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task DeleteTodoTest()
        { 
            var response = await _client.DeleteAsync("/api/Todo/1");
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

    }
}
