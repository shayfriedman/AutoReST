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

        public MappingException(ActionInfo actionInfo): 
            base(String.Format("Mapping for {0}.{1} with {2} parameters not found. Make sure you have your Conventions correctly in place",
            actionInfo.Controller, actionInfo.Name, actionInfo.Parameters != null ? actionInfo.Parameters.Count : 0))
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