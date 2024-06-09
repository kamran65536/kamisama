using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
	/// Exception localization key for localization
	/// </summary>
	public string ExceptionLocalizationKey { get; }
	/// <summary>
	/// Exception localization arguments
	/// </summary>
	public object?[] ExceptionLocalizationArguments { get; } = [];
	/// <summary>
	/// Extended properties for Problem Details error handling
	/// </summary>
	public Dictionary<string, object?> ExtendedProperties { get; set; } = [];
	/// <inheritdoc />
	protected HttpExceptionBase()
	{
        ExceptionLocalizationKey = this.GetType().Name;
	}
	/// <inheritdoc />
	protected HttpExceptionBase(string messageKey, params object?[] args) : base(TryFormatString(messageKey, args))
	{
		ExceptionLocalizationKey = messageKey;
		ExceptionLocalizationArguments = args;
	}
	/// <inheritdoc />
	protected HttpExceptionBase(string messageKey, object?[] args, Exception? innerException) : base(TryFormatString(messageKey, args), innerException)
	{
		ExceptionLocalizationKey = messageKey;
		ExceptionLocalizationArguments = args;
	}
	/// <summary>
	/// safely format string
	/// </summary>
	/// <param name="message"></param>
	/// <param name="args"></param>
	/// <returns></returns>
	protected static string TryFormatString(string message, params object?[] args)
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
