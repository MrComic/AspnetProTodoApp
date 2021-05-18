using Framework.Core.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Framework.Domain.Entities;

namespace TodoApp.Core.Domain.Contracts
{
    public interface ICommandRepository<TEntity> : IUnitOfWork
        where TEntity : BaseEntity
    {
        void Delete(long id);
        void DeleteGraph(long id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        TEntity Get(long id);
        TEntity GetGraph(long id);
        
        bool Exists(Expression<Func<TEntity, bool>> expression);

        Task InsertAsync(TEntity entity);
        Task<TEntity> GetAsync(long id);
        Task<TEntity> GetGraphAsync(long id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    }
}
