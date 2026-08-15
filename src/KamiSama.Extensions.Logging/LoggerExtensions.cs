using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KamiSama.Extensions.Logging;

/// <summary>
/// Extends <see cref="ILogger" /> with method-entry tracing that infers the calling member and declaring type.
/// Use it to add consistent diagnostic entry events without repeating caller names in log statements.
/// </summary>
/// <remarks>
/// Caller inference creates a <see cref="StackTrace" /> on every call, even when Trace logging is disabled.
/// The inferred declaring type can be a compiler-generated state-machine type when called from an async method.
/// </remarks>
public static class LoggerExtensions
{
	/// <summary>
	/// Writes a Trace event for the inferred calling type and member name.
	/// Optionally includes selected argument values in the diagnostic event.
	/// </summary>
	/// <param name="logger">The logger that receives the Trace event.</param>
	/// <param name="caller">
	/// The calling member name supplied automatically by the compiler. Pass a value explicitly only to override
	/// the inferred member name.
	/// </param>
	/// <param name="argsToLog">
	/// The selected argument values to attach to the entry event. Avoid secrets, credentials, tokens, personal data,
	/// and other sensitive values.
	/// </param>
	/// <remarks>
	/// This method creates a stack trace before logging, so it adds stack-walking overhead even when Trace logging is
	/// disabled. Calls from async methods can report a compiler-generated state-machine type instead of the original
	/// declaring type. The current message template passes all supplied argument values through one <c>Args</c>
	/// placeholder; multiple values may therefore be rendered as an array rather than as individually named values.
	/// </remarks>
	public static void LogMethodEntry(this ILogger logger,
		[CallerMemberName] string caller = "", params object[] argsToLog)
	{
		var frame = new StackTrace().GetFrame(1);
		var method = frame?.GetMethod();
		var className = method?.DeclaringType?.FullName ?? "UnknownClass";

		if (argsToLog != null && argsToLog.Length > 0)
			logger.LogTrace("Method {Class}.{Method} with args [{Args}] is called.", className, caller, argsToLog);
		else
		logger.LogTrace("Method {Class}.{Method} is called.", className, caller);
		}
	}
