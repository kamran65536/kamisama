using KamiSama.Chassis.HttpExceptions;


namespace KamiSama.Modules.Identity.Exceptions;

public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
{
    public override int StatusCode => 500;
}
