namespace EmptyParcelLocker.API.CustomExceptions;

[Serializable]
public class NoContentException : Exception
{
    public NoContentException()
    {
    }

    public NoContentException(string propertyName) : base($"No content exception: {propertyName} has no content")
    {
    }
}