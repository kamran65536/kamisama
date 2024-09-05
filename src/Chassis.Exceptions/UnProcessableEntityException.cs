namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The request was well-formed but was unable to be followed due to semantic errors.
/// </summary>
public class UnProcessableEntityException : HttpExceptionBase
{
    /// <inheritdoc />
    public override int StatusCode => 422;
    /// <inheritdoc />
    public UnProcessableEntityException()
    {
    }
    /// <inheritdoc />
    public UnProcessableEntityException(string messageKey, params object?[] args) : base(messageKey, args)
    {
    }
    /// <inheritdoc />
    public UnProcessableEntityException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
