using Framework.Core.Domain.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Domain.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region Query Dispatcher

        public Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TData>>();
            return handler.Handle(query);
        }
        #endregion


    }
}
