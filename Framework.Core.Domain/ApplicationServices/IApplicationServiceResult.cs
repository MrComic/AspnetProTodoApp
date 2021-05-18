using System.Collections.Generic;

namespace Framework.Core.Domain.ApplicationServices
{
    public interface IApplicationServiceResult
    {
        IEnumerable<string> Messages { get; }
        ApplicationServiceStatus Status { get; set; }
    }
}