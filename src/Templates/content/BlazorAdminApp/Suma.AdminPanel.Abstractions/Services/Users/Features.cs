namespace Suma.AdminPanel.Services.Users;

public interface IListUsers : IListFeature<UserListItemDto, UserSearchModel>;
public interface IAddUser
{
	Task AddAsync(AddUserRequest request, CancellationToken cancellationToken);
}
public interface IUpdateUser
{
	Task UpdateAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken);
}
public interface IFindUserById
{
	Task<UserDto> FindByIdAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IEnableUser
{
	Task EnableAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IDisableUser
{
	Task DisableAsync(Guid userId, CancellationToken cancellationToken);
}
public interface IResetUserPassword
{
	Task ResetPasswordAsync(ResetUserPasswordRequest request, CancellationToken cancellationToken);
}

