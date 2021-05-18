using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;

namespace TodoApp.Core.ApplicationServices.Test.Todo
{
    public static class FakeData
    {
        public static void InsertFakeData(TodoDbContext context,int count) {
            for (int i = 0; i <= count; i++)
            {
                context.Todos.Add(
                    new Domain.Todos.Entities.Todo("test"+i,"test"+i,DateTime.Now.AddDays(i+1)));
            }
            context.SaveChanges();
        }

        public static void InsertFakeData(QueryDbContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Todos.Add(
                    new Infra.Data.SqlServer.Queries.Todo.Entities.Todo() { 
                        Text = "test" + i, Title = "test" + i, ValidTo = DateTime.Now.AddDays(i + 1)
                    });
            }
            context.SaveChanges();
        }
    }
}
