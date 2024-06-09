using System;
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
    public ServiceUnavailableException(string serviceName) : base($"{serviceName} is not currently available")
    {
    }


    /// <inheritdoc />
    public ServiceUnavailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    /// <inheritdoc />
    public override int StatusCode => StatusCodes.Status503ServiceUnavailable;
}