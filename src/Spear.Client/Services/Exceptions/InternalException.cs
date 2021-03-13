using System;
using System.Runtime.Serialization;

namespace Spear.Client.Services.Exceptions
{
    public class InternalException : Exception
    {
        public InternalException()
        { }

        public InternalException(string message) : base(message)
        { }

        public InternalException(string message, Exception innerException) : base(message, innerException)
        { }

        protected InternalException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
