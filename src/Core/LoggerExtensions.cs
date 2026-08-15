using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KamiSama.Extensions;

/// <summary>
/// Provides diagnostic logging extensions for <see cref="ILogger"/>.
/// Use them to emit consistent trace-level method-entry messages.
/// </summary>
public static class LoggerExtensions
{
	/// <summary>
	/// Logs a trace-level method-entry message containing the caller name and any supplied argument values.
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="caller"></param>
	/// <param name="argsToLog"></param>
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
