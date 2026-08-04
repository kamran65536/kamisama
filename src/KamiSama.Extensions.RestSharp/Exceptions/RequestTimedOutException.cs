using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.Extensions.RestSharp.Exceptions;
/// <summary>
/// This is a UI response exception and should not be used in backend
/// </summary>
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
{
	public override int StatusCode => -1;
}
