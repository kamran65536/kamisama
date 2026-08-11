using KamiSama.Modules.Identity.Services.Users;

namespace KamiSama.Modules.Identity.Services.Password;

[AutoInjectScoped<IResetPassword>]
internal class Res(IUserManager userManager) : IResetPassword
{
	public async Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken)
	{
		ApplicationUser? user;
		if (request.Identity.Contains('@'))
			user = await userManager.FindByEmailAsync(request.Identity);
		else
			user = await userManager.FindByNameAsync(request.Identity);

		if (user is null)
			throw new NotFoundException<ApplicationUser>(request.Identity);

		var token = await userManager.GeneratePasswordResetTokenAsync(user);
		var result = await userManager.ResetPasswordAsync(user, token, request.Password);

		if (!result.Succeeded)
			throw new InvalidOperationHttpException($"reset password failed: {0}", string.Join(", ", result.Errors.Select(e => e.Description)));
	}
}
