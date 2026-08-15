using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;

/// <summary>
/// Represents an invalid or unusable response returned by an external service.
/// The service name and response details are retained as localization arguments.
/// </summary>
/// <param name="serviceName">The name of the external service that returned the invalid response.</param>
/// <param name="details">Details that identify or explain the invalid response.</param>
public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
{
	/// <summary>
	/// Gets the HTTP 500 Internal Server Error status code.
	/// </summary>
    public override int StatusCode => 500;
}
