using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.Extensions.RestSharp.Exceptions;
/// <summary>
/// Represents an invalid response received by a UI client from a remote server.
/// This exception uses the application-specific status code <c>-2</c> and is not intended for backend HTTP responses.
/// </summary>
/// <param name="args">Values stored as localization arguments for the exception key.</param>
public class InvalidResponseFromServerException(params object[] args) : HttpExceptionBase(nameof(InvalidResponseFromServerException), args)
{
	/// <summary>
	/// Gets the application-specific invalid-response status code <c>-2</c>.
	/// </summary>
	public override int StatusCode => -2;
}
