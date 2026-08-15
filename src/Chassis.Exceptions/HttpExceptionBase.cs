using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Provides the common HTTP status and localization metadata carried by KamiSama HTTP exceptions.
/// </summary>
/// <remarks>The exception itself does not write an HTTP response. A transport adapter such as KamiSama.Chassis.ProblemDetails must convert it at the application boundary.</remarks>
[ExcludeFromCodeCoverage]
public abstract class HttpExceptionBase : Exception
{
	/// <summary>
	/// Gets the HTTP status code associated with the failure.
	/// </summary>
	public abstract int StatusCode { get; }
	/// <summary>
	/// Gets the resource key used to localize the exception message.
	/// </summary>
	public string ExceptionLocalizationKey { get; }
	/// <summary>
	/// Gets the values supplied when formatting the localized exception message.
	/// </summary>
	public object?[] ExceptionLocalizationArguments { get; } = [];
	/// <summary>
	/// Gets or sets additional values that an error-response adapter may expose.
	/// </summary>
	public Dictionary<string, object?> ExtendedProperties { get; set; } = [];
	/// <summary>Initializes an exception whose localization key is the runtime exception type name.</summary>
	protected HttpExceptionBase()
	{
        ExceptionLocalizationKey = this.GetType().Name;
	}
	/// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	protected HttpExceptionBase(string messageKey, params object?[] args) : base(TryFormatString(messageKey, args))
	{
		ExceptionLocalizationKey = messageKey;
		ExceptionLocalizationArguments = args;
	}
	/// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
	/// <param name="messageKey">The localization key, also used as the fallback message format.</param>
	/// <param name="args">Values used to format and later localize the message.</param>
	/// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
	protected HttpExceptionBase(string messageKey, object?[] args, Exception? innerException) : base(TryFormatString(messageKey, args), innerException)
	{
		ExceptionLocalizationKey = messageKey;
		ExceptionLocalizationArguments = args;
	}
	/// <summary>
	/// Formats a message without allowing an invalid composite format string to throw.
	/// </summary>
	/// <param name="message">The composite format string or fallback text.</param>
	/// <param name="args">Values to insert into the format string.</param>
	/// <returns>The formatted message, or the original message when formatting fails.</returns>
	public static string TryFormatString(string message, params object?[] args)
    {
		try
		{
			return string.Format(message, args);
		}
		catch
		{
			return message;
		}
    }
}
