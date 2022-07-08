namespace ECommercenet6.Application.Exceptions;

public class UserCreatedFailedException:Exception
{
    public UserCreatedFailedException():base("Unexcepted Error while creating User")
    {
        
    }

    public UserCreatedFailedException(string?message ):base(message)
    {
        
    }

    public UserCreatedFailedException(string? message ,Exception? innerException):base(message,innerException)
    {
        
    }
}