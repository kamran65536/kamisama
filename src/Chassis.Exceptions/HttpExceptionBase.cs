using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// base Exception class for all Janus Services
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class HttpExceptionBase : Exception
{
	/// <summary>
	/// HTTP Status code to return
	/// </summary>
	public abstract int StatusCode { get; }
	/// <summary>
	/// Extended properties for Problem Details error handling
	/// </summary>
	public Dictionary<string, object?> ExtendedProperties { get; set; } = [];
	/// <inheritdoc />
	protected HttpExceptionBase()
	{
	}
	/// <inheritdoc />
	protected HttpExceptionBase(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	protected HttpExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
	/// <inheritdoc />
	protected HttpExceptionBase(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
