namespace SportEvents.Application.Exceptions;
public class InternalServerException : Exception
{
    public InternalServerException() : base("Something went wrong")
    {
    }

    public InternalServerException(string message) : base(message)
    {
    }
}
