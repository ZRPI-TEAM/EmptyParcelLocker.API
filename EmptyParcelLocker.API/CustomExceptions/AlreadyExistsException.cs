
namespace EmptyParcelLocker.API.CustomExceptions;

public class AlreadyExistsException : Exception 
{
    public AlreadyExistsException()
    {
        
    }

    public AlreadyExistsException(string typeName, Guid instanceId) : base(
        $"Already exists exception: entity {typeName} already exists with id: {instanceId}")
    {
        
    }
}