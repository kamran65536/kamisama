namespace KamiSama.Modules.Identity.Services.Users;

public interface IFindCurrentUser
{
	Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
}
public interface IAddUser : IAddFeature<AddUserRequest, UserDto>;
public interface IUpdateUser : IUpdateFeature<UpdateUserRequest, Guid>;
public interface IDeleteUser : IDeleteFeature<Guid>;
public interface IDisable2fa
{
	Task DisableAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IEnable2fa
{
	Task EnableAsync(Enable2faRequest request, CancellationToken cancellationToken);
}
public interface IDisableUser
{
	Task DisableUserAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IEnableUser
{
	Task EnableUserAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IExistsUserById : IExistsByIdFeature<Guid>;
public interface IFindUserById : IFindByIdFeature<UserDto, Guid>;
public interface IExistsUserByName : IExistsByNameFeature;
public interface IFindUserByName : IFindByNameFeature<UserDto>;
public interface IListUsers : IListFeature<UserDto, UserSearchModel>;

public interface IExistsUserByEmail
{
	Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
}
public interface IFindUserByEmail
{
	Task<UserDto> FindByEmailAsync(string email, CancellationToken cancellationToken);
}
public interface IAuthenticateUser
{
	Task<UserDto> AuthenticateAsync(AuthenticateUserRequest request, CancellationToken cancellationToken);
}
public interface IRefreshAccessToken
{
	Task<RefreshAccessTokenResponse> RefreshAsync(RefreshAccessTokenRequest request, CancellationToken cancellationToken);
}
public interface ITokenService
{
	Task<string> GenerateAccessTokenAsync(Guid userId, CancellationToken cancellationToken);
	Task<string> GenerateAccessTokenAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
	Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, CancellationToken cancellationToken);
	Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
	Task<string> GenerateRefreshTokenAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
}
