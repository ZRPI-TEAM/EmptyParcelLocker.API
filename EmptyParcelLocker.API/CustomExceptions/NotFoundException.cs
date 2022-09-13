namespace EmptyParcelLocker.API.CustomExceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string entityName, string searchKey) : base(
        $"Not found exception: Could not found {entityName} by key {searchKey}")
    {
        
    }
}