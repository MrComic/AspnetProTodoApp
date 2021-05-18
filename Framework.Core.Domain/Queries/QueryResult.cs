using Framework.Core.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Domain.Queries
{
    public sealed class QueryResult<TData> : ApplicationServiceResult
    {
        internal TData _data;
        public TData Data
        {
            get
            {
                return _data;
            }
        }
    }
}
