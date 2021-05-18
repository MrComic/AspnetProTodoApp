using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Contracts;
using TodoApp.Core.Domain.Todos.Data;
using Framework.Core.Domain.Data;
using TodoApp.Framework.Domain.Entities;

namespace TodoApp.Infra.Data.SqlServer
{
    public class BaseCommandRepository<TEntity, TDbContext> : ICommandRepository<TEntity>, IUnitOfWork
       where TEntity : BaseEntity
       where TDbContext : BaseCommandDbContext
    {
        protected readonly TDbContext _dbContext;

        public BaseCommandRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void ICommandRepository<TEntity>.Delete(long id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        void ICommandRepository<TEntity>.Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        void ICommandRepository<TEntity>.DeleteGraph(long id)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            var entity = query.FirstOrDefault(c => c.Id == id);
            if (entity?.Id != null)
                _dbContext.Set<TEntity>().Remove(entity);
        }

        TEntity ICommandRepository<TEntity>.Get(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        TEntity ICommandRepository<TEntity>.GetGraph(long id)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            var temp = graphPath.ToList();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(c => c.Id == id);
        }

        void ICommandRepository<TEntity>.Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        bool ICommandRepository<TEntity>.Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Any(expression);
        }

        async Task ICommandRepository<TEntity>.InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }
        async Task<TEntity> ICommandRepository<TEntity>.GetAsync(long id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        async Task<TEntity> ICommandRepository<TEntity>.GetGraphAsync(long id)
        {
            var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            var temp = graphPath.ToList();
            foreach (var item in graphPath)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task<bool> ICommandRepository<TEntity>.ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(expression);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }


      
    }
}
