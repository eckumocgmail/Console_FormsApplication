using System;
using System.Runtime.Serialization;

[Serializable]
public class UnsupportedException : Exception
{
    public UnsupportedException()
    {
    }

    public UnsupportedException(string message) : base(message)
    {
    }

    public UnsupportedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected UnsupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}