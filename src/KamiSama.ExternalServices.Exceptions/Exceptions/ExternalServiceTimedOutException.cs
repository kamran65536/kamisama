using KamiSama.Chassis.HttpExceptions;

namespace KamiSama.ExternalServices.Exceptions.Exceptions;

public class ExternalServiceTimedOutException(string serviceName, string details) :
    HttpExceptionBase(nameof(ExternalServiceTimedOutException), serviceName, details)
{
    public override int StatusCode => 504;
}
