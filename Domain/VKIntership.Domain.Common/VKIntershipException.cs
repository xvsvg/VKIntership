namespace VKIntership.Domain.Common;

public abstract class VKIntershipException : Exception
{
    protected VKIntershipException() : base() { }

    protected VKIntershipException(string message) : base(message) { }

    protected VKIntershipException(string message, Exception innerException) : base(message, innerException) { }
}