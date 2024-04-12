using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// The request contained valid data and was understood by the server, but the server is refusing action.
/// </summary>
[ExcludeFromCodeCoverage]
public class ForbiddenException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status403Forbidden;
	/// <inheritdoc />
	public ForbiddenException()
	{
	}
	/// <inheritdoc />
	public ForbiddenException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public ForbiddenException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
