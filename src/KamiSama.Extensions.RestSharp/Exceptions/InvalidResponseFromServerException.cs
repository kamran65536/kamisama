using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.Extensions.RestSharp.Exceptions;
/// <summary>
/// This is a UI response exception and should not be used in backend
/// </summary>
public class InvalidResponseFromServerException(params object[] args) : HttpExceptionBase(nameof(InvalidResponseFromServerException), args)
{
	public override int StatusCode => -2;
}
