using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IAddUser>]
internal class AddUser(
	ILogger<AddUser> logger,
	Polareum.Identity.Features.Users.IAddUser identityAddUser) : IAddUser
{
	public async Task AddAsync(AddUserRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			await identityAddUser.AddAsync(
				new Polareum.Identity.Features.Users.AddUserRequest(
					request.Username,
					request.Email,
					string.Empty,
					request.Password,
					request.IsEnabled,
					[KnownRoles.User]),
				cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to add user {Username}.", request.Username);
			throw;
		}
	}
}

