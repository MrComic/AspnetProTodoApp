using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Domain.Todos.Commands
{
    public class Create:ICommand<long>
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
