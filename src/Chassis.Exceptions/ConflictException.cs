using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.
/// </summary>
public class ConflictException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status409Conflict;
	/// <inheritdoc/>
	public ConflictException()
	{
	}
	/// <inheritdoc/>
	public ConflictException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <inheritdoc/>
	public ConflictException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}	
}
