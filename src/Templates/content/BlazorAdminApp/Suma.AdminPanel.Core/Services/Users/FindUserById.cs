using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IFindUserById>]
internal class FindUserById(
	ILogger<FindUserById> logger,
	Polareum.Identity.Features.Users.IFindUserById identityFindUserById,
	IFindCurrentUser findCurrentUser) : IFindUserById
{
	public async Task<UserDto> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await identityFindUserById.FindByIdAsync(userId, cancellationToken);
			if (!identityUser.Roles.Contains(KnownRoles.User))
				throw new NotFoundException("user.not.found", userId, nameof(userId));

			return identityUser.ToUserDto(currentUser.Id);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to find user {UserId}.", userId);
			throw;
		}
	}
}

