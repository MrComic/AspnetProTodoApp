using Framework.Core.Domain.ApplicationServices;
using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Commands;
using TodoApp.Core.Domain.Todos.Data;
using Framework.Core.Domain.Data;

namespace TodoApp.Core.ApplicationServices.Todos.CommandHandlers
{
    public class DeleteHandler: CommandHandler<Delete>
    {
        private readonly IUnitOfWork unitOfWork;
    private readonly ITodoRepository todoRepository;

    public DeleteHandler(IUnitOfWork unitOfWork,
                         ITodoRepository todoRepository)
    {
        this.unitOfWork = unitOfWork;
        this.todoRepository = todoRepository;
    }

    public override Task<CommandResult> Handle(Delete request)
    {
            todoRepository.Delete(request.Id);
            unitOfWork.Commit();
            return OkAsync();
    }
}
}
