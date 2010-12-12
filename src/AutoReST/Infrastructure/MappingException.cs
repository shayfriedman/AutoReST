using System;
using System.Runtime.Serialization;

namespace AutoReST.Infrastructure
{
    public class MappingException : Exception
    {

        public ActionInfo ActionInfo { get; private set; }

        public MappingException()
        {
        }

        public MappingException(ActionInfo actionInfo)
        {
            ActionInfo = actionInfo;
        }

        public MappingException(string message) : base(message)
        {
        }

        public MappingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MappingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}