using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Domain.Data;

namespace TodoApp.Infra.Data.SqlServer
{
    public class TodosUnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _dbContext;

        public TodosUnitOfWork(TodoDbContext dbContext)
        {
                    _dbContext = dbContext;
        }
        public int Commit()
        {
            var entityForSave = GetEntityForSave();
            int result = _dbContext.SaveChanges();
            return result;
        }

        private List<EntityEntry> GetEntityForSave()
        {
            return _dbContext.ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
              .ToList();
        }
    }
}
