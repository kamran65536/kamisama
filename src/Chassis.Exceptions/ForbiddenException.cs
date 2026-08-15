namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Represents an understood request that the server refuses to perform and should be reported with HTTP status code 403.
/// </summary>
public class ForbiddenException : HttpExceptionBase
{
	/// <summary>Gets HTTP status code 403.</summary>
	public override int StatusCode => 403;
	/// <summary>Initializes an exception using the exception type name as its localization key.</summary>
	public ForbiddenException()
	{
	}
	/// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	public ForbiddenException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	/// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
	public ForbiddenException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
