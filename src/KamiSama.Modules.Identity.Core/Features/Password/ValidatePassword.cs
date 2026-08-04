namespace KamiSama.Modules.Identity.Features.Password;

[AutoInjectScoped<IValidatePassword>]
internal class ValidatePassword(ILogger<ValidatePassword> logger, IUserManager userManager) : IValidatePassword
{
	public async Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();
		ApplicationUser? user = null;

		if (request.Username != null)
			user = await userManager.FindByNameAsync(request.Username);
		else if (request.Email != null)
			user = await userManager.FindByEmailAsync(request.Email);
		else if (request.PhoneNumber != null)
			user = await userManager.FindByNameAsync(request.PhoneNumber); //TODO add find by phone number method
		
		user ??= new();

		var result = await userManager.ValidatePasswordAsync(user, request.Password, cancellationToken);

		return [.. result.Select(x => new PasswordValidationError(x.Code, x.Description))];
	}
}
