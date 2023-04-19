using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.
/// </summary>
[ExcludeFromCodeCoverage]
public class ConflictException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status409Conflict;
	/// <inheritdoc/>
	public ConflictException()
	{
	}
	/// <inheritdoc/>
	public ConflictException(string? message) : base(message)
	{
	}
	/// <inheritdoc/>
	public ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
	/// <inheritdoc/>
	public ConflictException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
