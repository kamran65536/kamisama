namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Represents a client request that cannot be processed and should be reported with HTTP status code 400.
/// </summary>
public class BadRequestException : HttpExceptionBase
{
	/// <summary>Gets HTTP status code 400.</summary>
	public override int StatusCode => 400;

	/// <summary>Initializes an exception using the exception type name as its localization key.</summary>
	public BadRequestException()
	{
	}
	/// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	public BadRequestException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
}
