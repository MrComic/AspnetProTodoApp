using Framework.Core.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.ApplicationServices.Todos.CommandHandlers;
using TodoApp.Core.Domain.Todos.Commands;
using TodoApp.Core.Domain.Todos.Events;
using TodoApp.Core.Domain.Todos.Queries;
using TodoApp.Core.Domain.Todos.QueryModels;
using TodoApp.Endpoints.Api.Controllers.Base;
using TodoApp.Endpoints.Api.Model;

namespace TodoApp.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(Create request)
        {
            return await Create<Create, long>(request);
        }

        [HttpPut]
        [Route("Finish")]
        public async Task<IActionResult> Put(TodoFinished request)
        {
            return await Edit<TodoFinished>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            return await Delete<Delete>(new Delete(Id));
        }

        [HttpPost]
        [Route("List")]
        public async Task<IActionResult> Get(TodoListQuery request)
        {
            return await Query<TodoListQuery, PagedData<TodoViewModel>>(request);
        }
    }
}
