using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;

/// <summary>
/// Represents a server error caused by the absence of a configured external service implementation.
/// The service name and configuration value are retained as localization arguments.
/// </summary>
/// <param name="serviceName">The external service contract or integration name.</param>
/// <param name="serviceConfiguration">The configured provider or service value that could not be resolved.</param>
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
{
	/// <summary>
	/// Gets the HTTP 500 Internal Server Error status code.
	/// </summary>
	public override int StatusCode => 500;
}
