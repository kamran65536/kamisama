using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Identity.Features.Users;

public record AddUserRequest(string UserName, string Email, string MobileNumber, string Password, bool Activate, string[] Roles);
public record UpdateUserRequest(string UserName, string Email, string MobileNumber, string[] Roles);
public record UserDto(Guid Id, string Username, string Email, string[] Roles, bool IsEnabled);
public record AuthenticateUserRequest(Guid? UserId, string? Username, string? Email, string Password, string? TwoFactorCode = null);
public record RefreshAccessTokenRequest(string AccessToken, string RefreshToken);
public record RefreshAccessTokenResponse(string AccessToken, string RefreshToken);
public record TokenPairDto(string AccessToken, string RefreshToken);
public record Enable2faRequest(Guid UserId, string VerificationCode);
public record UserSearchModel(int Page, int PageSize, string? UsernameOrEmail, string? RoleName, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
{
	public static new readonly UserSearchModel All = new(0, 0, default, default, default);
}
