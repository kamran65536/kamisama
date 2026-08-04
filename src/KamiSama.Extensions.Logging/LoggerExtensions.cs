using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KamiSama.Extensions.Logging;

public static class LoggerExtensions
{
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