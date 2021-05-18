using Framework.Core.Domain.ApplicationServices;
using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Commands;
using TodoApp.Core.Domain.Todos.Data;
using TodoApp.Core.Domain.Todos.Entities;
using TodoApp.Core.Domain.Todos.Events;
//using TodoApp.Framework.Domain.ApplicationServices;
using Framework.Core.Domain.Data;
using TodoApp.Framework.Domain.Exceptions;

namespace TodoApp.Core.ApplicationServices.Todos.CommandHandlers
{
    public class FinishTodoHandler : CommandHandler<TodoFinished>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITodoRepository todoRepository;

        public FinishTodoHandler(IUnitOfWork unitOfWork,
                             ITodoRepository todoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.todoRepository = todoRepository;
        }

        public override Task<CommandResult> Handle(TodoFinished request)
        {
            var toDo = todoRepository.Get(request.Id);
            if (toDo == null)
            {
                throw new CustomExceptionsBase("مورد خواسته شده موجود نمی باشد");
            }
            else
            {
                toDo.HasFinished();
            }
            unitOfWork.Commit();
            return OkAsync();
        }

    }
}
