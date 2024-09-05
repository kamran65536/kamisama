namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// The request contained valid data and was understood by the server, but the server is refusing action.
/// </summary>
public class ForbiddenException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => 403;
	/// <inheritdoc />
	public ForbiddenException()
	{
	}
	/// <inheritdoc />
	public ForbiddenException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <inheritdoc />
	public ForbiddenException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
