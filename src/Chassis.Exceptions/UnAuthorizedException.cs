using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Thrown when the operation requested is not authorized
/// </summary>
[ExcludeFromCodeCoverage]
public class UnAuthorizedException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status401Unauthorized;
	/// <inheritdoc />
	public UnAuthorizedException()
	{
	}
	/// <inheritdoc />
	public UnAuthorizedException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <inheritdoc />
	public UnAuthorizedException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
