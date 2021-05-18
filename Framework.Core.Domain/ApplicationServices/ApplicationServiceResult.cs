using System.Collections.Generic;

namespace Framework.Core.Domain.ApplicationServices
{
    public abstract class ApplicationServiceResult : IApplicationServiceResult
    {
        protected readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Messages => _messages;

        public ApplicationServiceStatus Status { get; set; }

        public void AddMessage(string error)
        {
            _messages.Add(error);
        }

        public void ClearMessages()
        {
            _messages.Clear();
        }
    }
}