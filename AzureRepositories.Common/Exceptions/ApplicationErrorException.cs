using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepositories.Common.Exceptions
{
    public class ApplicationErrorException : Exception
    {
        public ApplicationErrorException(Exception ex)
        {
            this.ExceptionId = Guid.NewGuid().ToString();
            this.ApplicationException = ex;
            this.ApplicationInnerException = ex?.InnerException;
            this.RaisedTime = DateTime.UtcNow;
        }
        public string ExceptionId { get; private set; }
        public Exception ApplicationException { get; private set; }

        public Exception ApplicationInnerException { get; private set; }

        public DateTime RaisedTime { get; set; }

        public override string StackTrace => this.ApplicationException.StackTrace;

        public override string Message => this.ApplicationException.Message;

    }
}
