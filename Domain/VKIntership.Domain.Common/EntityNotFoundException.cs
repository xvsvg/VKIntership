namespace VKIntership.Domain.Common;

public class EntityNotFoundException : VKIntershipException
{
    public EntityNotFoundException(string message) : base(message) { }
}