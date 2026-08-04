namespace KamiSama.Modules.Identity.Features.Password;

public interface IValidatePassword
{
	Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken);
}
public interface IResetPassword
{
	Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken);
}