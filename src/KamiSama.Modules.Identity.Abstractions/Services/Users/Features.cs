namespace KamiSama.Modules.Identity.Services.Users;

/// <summary>Resolves the user represented by the current execution context.</summary>
public interface IFindCurrentUser
{
	/// <summary>Returns the current user.</summary>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The current user's provider-neutral representation.</returns>
	Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
}
/// <summary>Creates a user through the standard add-feature contract.</summary>
public interface IAddUser : IAddFeature<AddUserRequest, UserDto>;
/// <summary>Updates the user identified by a <see cref="Guid"/>.</summary>
public interface IUpdateUser : IUpdateFeature<UpdateUserRequest, Guid>;
/// <summary>Deletes the user identified by a <see cref="Guid"/>.</summary>
public interface IDeleteUser : IDeleteFeature<Guid>;
/// <summary>Disables two-factor authentication for a user.</summary>
public interface IDisable2fa
{
	/// <summary>Disables two-factor authentication for the specified user.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the update.</returns>
	Task DisableAsync(Guid userId, CancellationToken cancellationToken);
}
/// <summary>Enables two-factor authentication after validating an authenticator code.</summary>
public interface IEnable2fa
{
	/// <summary>Enables two-factor authentication using the supplied setup verification.</summary>
	/// <param name="request">The target user and authenticator verification code.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the update.</returns>
	Task EnableAsync(Enable2faRequest request, CancellationToken cancellationToken);
}
/// <summary>Disables a user's ability to authenticate according to implementation-defined lockout semantics.</summary>
public interface IDisableUser
{
	/// <summary>Disables the specified user.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the update.</returns>
	Task DisableUserAsync(Guid userId, CancellationToken cancellationToken);
}
/// <summary>Enables a user according to implementation-defined lockout semantics.</summary>
public interface IEnableUser
{
	/// <summary>Enables the specified user.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the update.</returns>
	Task EnableUserAsync(Guid userId, CancellationToken cancellationToken);
}
/// <summary>Checks whether a user exists for a <see cref="Guid"/> identifier.</summary>
public interface IExistsUserById : IExistsByIdFeature<Guid>;
/// <summary>Finds a user by a <see cref="Guid"/> identifier.</summary>
public interface IFindUserById : IFindByIdFeature<UserDto, Guid>;
/// <summary>Checks whether a user exists for a user name.</summary>
public interface IExistsUserByName : IExistsByNameFeature;
/// <summary>Finds a user by user name.</summary>
public interface IFindUserByName : IFindByNameFeature<UserDto>;
/// <summary>Lists users through the standard paged feature contract.</summary>
public interface IListUsers : IListFeature<UserDto, UserSearchModel>;

/// <summary>Checks whether a user exists for an email address.</summary>
public interface IExistsUserByEmail
{
	/// <summary>Returns whether a user has the supplied email address.</summary>
	/// <param name="email">The email address to look up.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns><see langword="true"/> when a matching user exists; otherwise <see langword="false"/>.</returns>
	Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
}
/// <summary>Finds a user by email address.</summary>
public interface IFindUserByEmail
{
	/// <summary>Returns the user with the supplied email address.</summary>
	/// <param name="email">The email address to look up.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The matching user.</returns>
	Task<UserDto> FindByEmailAsync(string email, CancellationToken cancellationToken);
}
