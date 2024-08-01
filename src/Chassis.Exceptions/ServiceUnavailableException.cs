using Microsoft.AspNetCore.Http;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Thrown when some external service is not available
/// </summary>
public class ServiceUnavailableException : HttpExceptionBase
{
    /// <inheritdoc />
    public ServiceUnavailableException()
    {
    }

    /// <summary>
    ///  Thrown when some external service is not available
    /// </summary>
    /// <param name="serviceName">Name of the service that is not available</param>
    public ServiceUnavailableException(string serviceName) : base(nameof(ServiceUnavailableException), serviceName)
    {
    }
    /// <inheritdoc />
    public ServiceUnavailableException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
    /// <inheritdoc />
    public override int StatusCode => StatusCodes.Status503ServiceUnavailable;
}