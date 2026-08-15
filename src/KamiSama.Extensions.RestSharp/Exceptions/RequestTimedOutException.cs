using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.Extensions.RestSharp.Exceptions;
/// <summary>
/// Represents a remote request timeout reported to a UI client.
/// This exception uses the application-specific status code <c>-1</c> and is not intended for backend HTTP responses.
/// </summary>
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
{
	/// <summary>
	/// Gets the application-specific request-timeout status code <c>-1</c>.
	/// </summary>
	public override int StatusCode => -1;
}
