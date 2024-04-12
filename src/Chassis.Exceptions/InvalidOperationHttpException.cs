using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Equivalant to <see cref="InvalidOperationException" /> but in the http mode
/// </summary>
public class InvalidOperationHttpException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status500InternalServerError;
	/// <inheritdoc />
	public InvalidOperationHttpException()
	{
	}
	/// <inheritdoc />
	public InvalidOperationHttpException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public InvalidOperationHttpException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
