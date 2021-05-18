using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Domain.Exceptions
{
    public class ValidationExceptionBase : Exception
    {
        public ValidationExceptionBase(string message) : base(message)
        {
        }

        public ValidationExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
