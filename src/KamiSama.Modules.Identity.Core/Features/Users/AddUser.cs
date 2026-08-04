using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IAddUser>]
internal class AddUser(IUserManager userManager) : IAddUser
{
	public async Task<UserDto> AddAsync(AddUserRequest request, CancellationToken cancellationToken)
	{
		var user = new ApplicationUser
		{
			UserName = request.UserName,
			Email = request.Email,
			PhoneNumber = request.MobileNumber,
		};
		IdentityResult result;

		if (request.Password != null)
			result = await userManager.CreateAsync(user, request.Password);
		else
			result = await userManager.CreateAsync(user);

		if (!result.Succeeded)
			throw new AddUserFailedException(result.Errors.FirstOrDefault()?.Description);

		if (request.Activate && userManager.Options.SignIn.RequireConfirmedAccount)
		{
			var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
			await userManager.ConfirmEmailAsync(user, token);
		}

		await userManager.AddToRolesAsync(user, request.Roles);

		var roles = await userManager.GetRolesAsync(user);

		return user.ToDto([..roles]);
	}
}
