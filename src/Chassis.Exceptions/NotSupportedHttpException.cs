using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;
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
	public NotSupportedHttpException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public NotSupportedHttpException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
