using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// he server either does not recognize the request method, or it lacks the ability to fulfil the request. 
/// </summary>
[ExcludeFromCodeCoverage]
public class NotImplementedHttpException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status501NotImplemented;
	/// <inheritdoc />
	public NotImplementedHttpException()
	{
	}
	/// <inheritdoc />
	public NotImplementedHttpException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public NotImplementedHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
	/// <inheritdoc />
	public NotImplementedHttpException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
