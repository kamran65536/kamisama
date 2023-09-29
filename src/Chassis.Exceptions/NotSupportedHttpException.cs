using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// he server either does not support the request method, or it lacks the ability to fulfil the request. 
/// </summary>
public class NotSupportedHttpException : HttpExceptionBase
{
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
	public NotSupportedHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
	/// <inheritdoc />
	public NotSupportedHttpException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
