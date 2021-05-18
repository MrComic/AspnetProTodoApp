using Framework.Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.Core.Domain.Contracts;
using TodoApp.Infra.Data.SqlServer.ExtentionMethods;
using System.Collections;
using System.Threading.Tasks;

namespace TodoApp.Infra.Data.SqlServer.Queries.Contracts
{
    public class BaseQueryRepository<TDbContext> : IQueryRepository
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        public BaseQueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedData<T>> PageQuery<T,TQuery>(IQueryable<T> query,TQuery request) where TQuery : PageQuery<PagedData<T>>
            
        {
            var p = new PagedData<T>();

                if (request.SortAscending)
                {
                    query = query.AsQueryable().OrderBy(request.SortBy);
                }
                else
                {
                    query = query.AsQueryable().OrderByDescending(request.SortBy);
                }
            p.TotalCount = request.NeedTotalCount ? query.Count() : 0;
            var res = query.Skip(request.SkipCount).Take(request.PageSize);
            p.QueryResult = await res.ToListAsync();
            p.PageSize = request.PageSize;
            p.PageNumber = request.PageNumber;
            return p;
        }
    }
}
