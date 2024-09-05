namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing).
/// </summary>
public class BadRequestException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => 400;

	/// <inheritdoc />
	public BadRequestException()
	{
	}
	/// <inheritdoc />
	public BadRequestException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
}
