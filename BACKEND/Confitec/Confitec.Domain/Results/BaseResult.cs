using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Confitec.Domain.Results
{
    public class BaseResult
    {       
        private readonly IList<string> _messages = new List<string>();

        public string Msg { get; set; }

        public IEnumerable<string> Errors { get; }
        public object Result { get; set; }

        public BaseResult() => Errors = new ReadOnlyCollection<string>(_messages);

        public BaseResult(object result) : this() => Result = result;

        public BaseResult AddError(string message)
        {
            _messages.Add(message);
            return this;
        }

        public BaseResult(object result, string msg)
        {
            Msg = msg;
            Result = result;
        }
    }
}
