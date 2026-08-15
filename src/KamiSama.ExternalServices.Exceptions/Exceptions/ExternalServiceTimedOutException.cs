using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;

/// <summary>
/// Represents an external service operation that did not complete before its timeout.
/// The service name and timeout details are retained as localization arguments.
/// </summary>
/// <param name="serviceName">The name of the external service that timed out.</param>
/// <param name="details">Details that identify or explain the timeout.</param>
public class ExternalServiceTimedOutException(string serviceName, string details) :
    HttpExceptionBase(nameof(ExternalServiceTimedOutException), serviceName, details)
{
	/// <summary>
	/// Gets the HTTP 504 Gateway Timeout status code.
	/// </summary>
    public override int StatusCode => 504;
}
