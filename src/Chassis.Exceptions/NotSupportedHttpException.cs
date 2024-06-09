using Microsoft.AspNetCore.Http;
using System;
namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// he server either does not support the request method, or it lacks the ability to fulfil the request. 
/// </summary>
public class NotSupportedHttpException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status500InternalServerError;
	/// <inheritdoc />
	public NotSupportedHttpException()
	{
	}
	/// <inheritdoc />
	public NotSupportedHttpException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <inheritdoc />
	public NotSupportedHttpException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
