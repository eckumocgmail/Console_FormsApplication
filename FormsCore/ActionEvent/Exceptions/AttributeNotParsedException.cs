using System;
using System.Runtime.Serialization;

[Serializable]
public class AttributeNotParsedException : Exception
{
    public AttributeNotParsedException()
    {
    }

    public AttributeNotParsedException(string message) : base(message)
    {
    }

    public AttributeNotParsedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected AttributeNotParsedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}