using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.Events;

namespace TodoApp.Core.Domain.Todos.Events
{
    public class TitleUpdated:IEvent
    {
        public string Title { get; set; }
    }
}
