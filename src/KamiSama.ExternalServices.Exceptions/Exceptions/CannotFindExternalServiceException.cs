using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
{
	public override int StatusCode => 500;
}
