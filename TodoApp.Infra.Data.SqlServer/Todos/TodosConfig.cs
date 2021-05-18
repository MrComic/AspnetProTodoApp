using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Core.Domain.Todos.Entities;
using TodoApp.Core.Domain.Todos.ValueObjects;

namespace TodoApp.Infra.Data.SqlServer.Todos
{
    public class TodosConfig : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(c => c.Title).HasConversion(c => c.Value, d => new Title(d));
            builder.Property(c => c.Text).HasConversion(c => c.Value, d => new Text(d));
            builder.Property(c => c.Done).HasConversion(c => c.Value, d => new Done(d));
            builder.Property(c => c.ValidTo).HasConversion(c => c.Value, d => new ValidTo(d));
        }
    }
}
