using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.Core.Domain.Todos.Entities;
using Xunit;
namespace TodoApp.Core.Domain.Test
{


    public class TodoTest
    {
        public Todo CreateDefaultTodo()
        {
            return new Todo("test", "test", DateTime.Now.AddMinutes(10));
        }

        [Fact]
        public void CreateInstanceFromTest() {
            var todo = CreateDefaultTodo();
            Assert.NotEmpty(todo.GetEvents());
        }

        [Fact]
        public void UpdateFinishFlag()
        {
            var todo = CreateDefaultTodo();
            todo.HasFinished();
            Assert.NotNull(todo.Done);
            Assert.Equal(2,Enumerable.Count<Framework.Domain.Events.IEvent>(todo.GetEvents()));
        }

        [Fact]
        public void UpdateTextTest()
        {
            var todo = CreateDefaultTodo();
            string newtext = "test1";
            todo.UpdateText(newtext);
            Assert.Equal(newtext, todo.Text);
            Assert.Equal(2, Enumerable.Count<Framework.Domain.Events.IEvent>(todo.GetEvents()));
        }

        [Fact]
        public void UpdateTitleTest()
        {
            var todo = CreateDefaultTodo();
            string newtitle = "test1";
            todo.UpdateTitle(newtitle);
            Assert.Equal(newtitle, todo.Title);
            Assert.Equal(2, Enumerable.Count<Framework.Domain.Events.IEvent>(todo.GetEvents()));
        }

    }
}
