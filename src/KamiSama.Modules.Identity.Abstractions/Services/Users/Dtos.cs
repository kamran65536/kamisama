using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Identity.Services.Users;

/// <summary>Contains identity, credential, activation, and role values requested when a user is created.</summary>
/// <param name="UserName">The new user's sign-in name.</param>
/// <param name="Email">The new user's email address.</param>
/// <param name="MobileNumber">The new user's mobile phone number.</param>
/// <param name="Password">The initial password.</param>
/// <param name="Activate">Whether the implementation should activate or confirm the account when supported.</param>
/// <param name="Roles">The role names requested for the new user.</param>
public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
/// <summary>Contains replacement profile and role values requested for an existing user.</summary>
/// <param name="UserName">The replacement sign-in name.</param>
/// <param name="Email">The replacement email address.</param>
/// <param name="MobileNumber">The replacement mobile phone number.</param>
/// <param name="Roles">The complete requested role-name set.</param>
public record UpdateUserRequest(string UserName, string Email, string MobileNumber, string[] Roles);
/// <summary>Transfers a user's identity, role names, and effective enabled state without exposing a provider entity.</summary>
/// <param name="Id">The user identifier.</param>
/// <param name="Username">The user name.</param>
/// <param name="Email">The email address.</param>
/// <param name="Roles">The current role names.</param>
/// <param name="IsEnabled">Whether the implementation considers the user enabled.</param>
public record UserDto(Guid Id, string Username, string Email, string[] Roles, bool IsEnabled);
/// <summary>Supplies a user and verification code when enabling two-factor authentication.</summary>
/// <param name="UserId">The target user identifier.</param>
/// <param name="VerificationCode">The authenticator code that proves setup succeeded.</param>
public record Enable2faRequest(Guid UserId, string VerificationCode);
/// <summary>Describes paging, identity text, role, and ordering criteria requested when users are listed.</summary>
/// <param name="Page">The one-based page number, or zero when requesting all results.</param>
/// <param name="PageSize">The maximum users in a page, or zero when requesting all results.</param>
/// <param name="UsernameOrEmail">Optional text used to filter by user name or email.</param>
/// <param name="RoleName">An optional role-name filter interpreted by the implementation.</param>
/// <param name="OrderBy">An optional implementation-defined ordering expression.</param>
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>Gets a search model that requests all users without filtering or explicit ordering.</summary>
	public static new readonly UserSearchModel All = new(0, 0, default, default, default);
}
