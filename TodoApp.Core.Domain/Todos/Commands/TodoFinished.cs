using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Domain.Todos.Commands
{
    public class TodoFinished : ICommand
    {
        public long Id { get; set; }
    }
}
