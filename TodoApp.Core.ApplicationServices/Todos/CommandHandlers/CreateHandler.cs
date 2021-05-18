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
using Framework.Core.Domain.Data;

namespace TodoApp.Core.ApplicationServices.Todos.CommandHandlers
{
    public class CreateHandler : CommandHandler<Create, long>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITodoRepository todoRepository;

        public CreateHandler(IUnitOfWork unitOfWork,
                             ITodoRepository todoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.todoRepository = todoRepository;
        }

        public override Task<CommandResult<long>> Handle(Create request)
        {
            var todoEntity = new Todo(request.Title, request.Text, request.ValidTo);
            todoRepository.Insert(todoEntity);
            unitOfWork.Commit();
            return OkAsync(todoEntity.Id);
        }
    }
}
