using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Represents an unauthenticated request that should be reported with HTTP status code 401.
/// </summary>
[ExcludeFromCodeCoverage]
public class UnAuthorizedException : HttpExceptionBase
{
	/// <summary>Gets HTTP status code 401.</summary>
	public override int StatusCode => 401;
	/// <summary>Initializes an exception using the exception type name as its localization key.</summary>
	public UnAuthorizedException()
	{
	}
	/// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	public UnAuthorizedException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	/// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
	public UnAuthorizedException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
