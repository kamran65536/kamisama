using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

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
	public UnAuthorizedException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public UnAuthorizedException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
