using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.Events;

namespace TodoApp.Core.Domain.Todos.Events
{
    public class TodoHasFinished:IEvent
    {
       public Guid Id { get; set; }
    }
}
