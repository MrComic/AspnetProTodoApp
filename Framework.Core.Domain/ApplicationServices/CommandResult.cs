using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Domain.ApplicationServices
{
    public class CommandResult : ApplicationServiceResult
    {

    }

    public class CommandResult<TData> : CommandResult
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
