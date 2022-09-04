using System;
using System.Runtime.Serialization;

namespace NetCoreConstructorAngular.Views.Shared.Components.Form
{
    [Serializable]
    public class SkipFieldException : Exception
    {
        public SkipFieldException()
        {
        }

        public SkipFieldException(string message) : base(message)
        {
        }

        public SkipFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SkipFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}