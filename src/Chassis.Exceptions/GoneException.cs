namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Represents a resource that is no longer available.
/// </summary>
/// <remarks>The current implementation reports status code 401 rather than the conventional 410 Gone status.</remarks>
public class GoneException : HttpExceptionBase
{
	/// <summary>Gets the current HTTP status code value, 401.</summary>
	public override int StatusCode => 401;
	/// <summary>Initializes an exception using the exception type name as its localization key.</summary>
	public GoneException()
    {
    }
    /// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
    /// <param name="message">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    public GoneException(string message, params object?[] args) : base(message, args)
    {
    }
    /// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
    /// <param name="messageKey">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    /// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
    public GoneException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
