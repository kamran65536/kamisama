namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Represents a temporary service outage that should be reported with HTTP status code 503.
/// </summary>
public class ServiceUnavailableException : HttpExceptionBase
{
	/// <summary>Gets HTTP status code 503.</summary>
	public override int StatusCode => 503;
	/// <summary>Initializes an exception using the exception type name as its localization key.</summary>
	public ServiceUnavailableException()
    {
    }

    /// <summary>
    /// Initializes an exception for a named unavailable service.
    /// </summary>
    /// <param name="serviceName">Name of the service that is not available</param>
    public ServiceUnavailableException(string serviceName) : base(nameof(ServiceUnavailableException), serviceName)
    {
    }
    /// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
    /// <param name="messageKey">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    /// <param name="innerException">The exception that caused the service outage, or <see langword="null"/>.</param>
    public ServiceUnavailableException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
