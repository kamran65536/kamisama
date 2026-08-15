namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Represents a semantically invalid request that should be reported with HTTP status code 422.
/// </summary>
public class UnProcessableEntityException : HttpExceptionBase
{
    /// <summary>Gets HTTP status code 422.</summary>
    public override int StatusCode => 422;
    /// <summary>Initializes an exception using the exception type name as its localization key.</summary>
    public UnProcessableEntityException()
    {
    }
    /// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
    /// <param name="messageKey">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    public UnProcessableEntityException(string messageKey, params object?[] args) : base(messageKey, args)
    {
    }
    /// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
    /// <param name="messageKey">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    /// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
    public UnProcessableEntityException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
