using System.Runtime.Serialization;

namespace CodeRefactoring.Exceptions;

[Serializable]
public class UnknownSystemException : Exception
{
    public UnknownSystemException() : base("Unknown system")
    {
    }

    public UnknownSystemException(string message) : base(message)
    {
    }

    public UnknownSystemException(string message, Exception inner) : base(message, inner)
    {
    }

    protected UnknownSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
