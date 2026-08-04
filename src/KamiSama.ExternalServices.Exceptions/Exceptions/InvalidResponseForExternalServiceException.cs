using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;

public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
{
    public override int StatusCode => 500;
}
