namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IUpdateUser>]
internal class UpdateUser(ILogger<UpdateUser> logger, IUserManager userManager) : IUpdateUser
{
	public async Task UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		var user = await userManager.FindByIdAsync(userManager.ConvertId(id), cancellationToken) ?? throw new NotFoundException<ApplicationUser>(id, nameof(id));

		user.UserName = request.UserName;
		user.NormalizedUserName = userManager.NormalizeName(request.UserName);
		user.Email = request.Email;
		user.NormalizedEmail = userManager.NormalizeEmail(request.Email);
		user.PhoneNumber = request.MobileNumber;
		
		await userManager.UpdateAsync(user, cancellationToken);
	}
}
