# KamiSama.Modules.Identity.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral Identity feature contracts, requests, responses, search models, role constants, and failure metadata for login, token refresh, logout, user, role, password, session, and two-factor workflows. Reference this package from callers or alternative implementations that should not depend on ASP.NET Core Identity, Entity Framework Core, or a database provider.

## How to use

```shell
dotnet add package KamiSama.Modules.Identity.Abstractions --version 10.0.0
```

Inject only the feature interfaces needed by an application service. The Core package discovers its implementations during module registration, while another provider can implement the same contracts without depending on ASP.NET Core Identity:

```csharp
using KamiSama.Modules.Identity.Services.AccountSecurity;
using KamiSama.Modules.Identity.Services.Authentication;
using KamiSama.Modules.Identity.Services.Roles;
using KamiSama.Modules.Identity.Services.Users;

public sealed class AccountFacade(
    ILogin login,
    IRefreshToken refreshToken,
    ILogout logout,
    IFindCurrentUser currentUser,
    IListRoles listRoles,
    IListActiveSessions sessions,
    IChangePassword changePassword)
{
    public Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken token) => login.LoginAsync(request, token);
    public Task<TokenPairDto> RefreshAsync(RefreshTokenRequest request, CancellationToken token) => refreshToken.RefreshAsync(request, token);
    public Task LogoutAsync(CancellationToken token) => logout.LogoutAsync(token);
    public Task<UserDto> CurrentAsync(CancellationToken token) => currentUser.GetCurrentUserAsync(token);
    public Task<IReadOnlyList<ActiveSessionDto>> SessionsAsync(Guid userId, CancellationToken token) => sessions.ListAsync(userId, token);
    public Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken token) => changePassword.ChangeAsync(request, token);
}
```

These are operation shapes, not an authorization boundary. `ILogin` accepts one user name or email value and returns both the authenticated user and a new session's tokens; `IRefreshToken` replaces tokens for the session represented by the supplied pair. `ILogout` and `ILogoutAll` rely on an implementation-defined current authenticated context. Implementations must authorize target user and role identifiers, avoid account-enumeration differences, define cancellation and transaction behavior, and protect token and password workflows. DTO arrays are mutable, and the contracts do not promise that search or update fields are honored by every implementation.

## Namespaces

- [KamiSama.Modules.Identity.DataTypes](kamisama-modules-identity-datatypes/index.md) (1 types)
- [KamiSama.Modules.Identity.Exceptions](kamisama-modules-identity-exceptions/index.md) (1 types)
- [KamiSama.Modules.Identity.Services.AccountSecurity](kamisama-modules-identity-services-accountsecurity/index.md) (11 types)
- [KamiSama.Modules.Identity.Services.Authentication](kamisama-modules-identity-services-authentication/index.md) (8 types)
- [KamiSama.Modules.Identity.Services.Password](kamisama-modules-identity-services-password/index.md) (5 types)
- [KamiSama.Modules.Identity.Services.Roles](kamisama-modules-identity-services-roles/index.md) (12 types)
- [KamiSama.Modules.Identity.Services.Users](kamisama-modules-identity-services-users/index.md) (20 types)

## Types

- [KamiSama.Modules.Identity.DataTypes.KnownRoles](kamisama-modules-identity-datatypes/kamisama-modules-identity-datatypes-knownroles/index.md) - Defines the canonical `SuperAdmin`, `Operator`, and `User` role-name strings. These constants neither seed roles nor grant authorization.
- [KamiSama.Modules.Identity.Exceptions.AddUserFailedException](kamisama-modules-identity-exceptions/kamisama-modules-identity-exceptions-adduserfailedexception/index.md) - Reports an Identity user-creation failure as HTTP 500 and retains only the first Identity error description as localization metadata.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ActiveSessionDto](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-activesessiondto/index.md) - Describes one active application session for account-security displays and revocation controls. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ChangePasswordRequest](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-changepasswordrequest/index.md) - Supplies current credentials and a replacement password for a password-change workflow. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.IChangePassword](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-ichangepassword/index.md) - Authenticates current credentials and changes a user&apos;s password. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.IGetAuthenticatorSecret](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-igetauthenticatorsecret/index.md) - Reads or creates the authenticator secret associated with a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.IIsTwoFactorAuthenticationEnabled](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-iistwofactorauthenticationenabled/index.md) - Checks whether two-factor authentication is enabled for a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.IListActiveSessions](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-ilistactivesessions/index.md) - Lists active sessions for a user; implementations define authorization and current-session detection. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ISetTwoFactorAuthenticationEnabled](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-isettwofactorauthenticationenabled/index.md) - Enables or disables two-factor authentication for a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateAllOtherSessions](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-iterminateallothersessions/index.md) - Revokes every active session for a user except the implementation-defined current session. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateSession](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-iterminatesession/index.md) - Revokes one session belonging to a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.IValidateAuthenticatorCode](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-ivalidateauthenticatorcode/index.md) - Validates a time-based authenticator code for a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.AccountSecurity.ValidateAuthenticatorCodeRequest](kamisama-modules-identity-services-accountsecurity/kamisama-modules-identity-services-accountsecurity-validateauthenticatorcoderequest/index.md) - Supplies a user identifier and time-based authenticator code for validation. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Authentication.ILogin](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-ilogin/index.md) - Defines credential validation and new-session token issuance as one operation. Core accepts a user name or email login, validates password and configured two-factor authentication, persists a revocable session, and returns its user and tokens.
- [KamiSama.Modules.Identity.Services.Authentication.ILogout](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-ilogout/index.md) - Defines revocation of the current authenticated application session. Core reads user and session claims from the active HTTP context and marks that session revoked in the Identity database.
- [KamiSama.Modules.Identity.Services.Authentication.ILogoutAll](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-ilogoutall/index.md) - Defines revocation of every application session for the current authenticated user, including the caller's session. Core resolves the user claim from the active HTTP context and persists revocation for all active sessions.
- [KamiSama.Modules.Identity.Services.Authentication.IRefreshToken](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-irefreshtoken/index.md) - Defines replacement-token issuance for the session represented by an access/refresh-token pair. Core validates access-token signature and claims, active session state, and the session-scoped refresh token before returning replacements.
- [KamiSama.Modules.Identity.Services.Authentication.LoginRequest](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-loginrequest/index.md) - Carries one user name or email address, a password, and an optional authenticator code into `ILogin`. Using one login value avoids conflicting identity selectors; the implementation defines lookup and normalization behavior.
- [KamiSama.Modules.Identity.Services.Authentication.LoginResponse](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-loginresponse/index.md) - Returns the provider-neutral authenticated user together with the token pair issued for a newly created session. Callers can establish identity state without invoking a separate public token-issuance service.
- [KamiSama.Modules.Identity.Services.Authentication.RefreshTokenRequest](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-refreshtokenrequest/index.md) - Carries the access and refresh tokens that identify and prove authority over an existing session. Implementations validate the pair before issuing replacements.
- [KamiSama.Modules.Identity.Services.Authentication.TokenPairDto](kamisama-modules-identity-services-authentication/kamisama-modules-identity-services-authentication-tokenpairdto/index.md) - Carries access and refresh tokens for one session plus the access token's absolute UTC expiration. Clients can schedule renewal without decoding provider-specific token contents.
- [KamiSama.Modules.Identity.Services.Password.IResetPassword](kamisama-modules-identity-services-password/kamisama-modules-identity-services-password-iresetpassword/index.md) - Resets a user&apos;s password according to implementation-defined identity lookup and token validation rules. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Password.IValidatePassword](kamisama-modules-identity-services-password/kamisama-modules-identity-services-password-ivalidatepassword/index.md) - Validates a candidate password against an implementation&apos;s configured password policy. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Password.PasswordValidationError](kamisama-modules-identity-services-password/kamisama-modules-identity-services-password-passwordvalidationerror/index.md) - Describes one password-policy validation failure. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Password.ResetPasswordRequest](kamisama-modules-identity-services-password/kamisama-modules-identity-services-password-resetpasswordrequest/index.md) - Supplies an identity lookup value and replacement password to a reset implementation. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Password.ValidatePasswordRequest](kamisama-modules-identity-services-password/kamisama-modules-identity-services-password-validatepasswordrequest/index.md) - Supplies optional identity context and a candidate password for policy validation. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.AddRoleRequest](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-addrolerequest/index.md) - Contains the name required to create a role. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IAddRole](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-iaddrole/index.md) - Creates a role and returns its provider-neutral representation. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IDeleteRole](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-ideleterole/index.md) - Deletes the role identified by a `Guid`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IExistsRoleById](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-iexistsrolebyid/index.md) - Checks whether a role exists for a `Guid` identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IExistsRoleByName](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-iexistsrolebyname/index.md) - Checks whether a role exists for a name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IFindRoleById](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-ifindrolebyid/index.md) - Finds a role by its `Guid` identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IFindRoleByName](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-ifindrolebyname/index.md) - Defines the contract for `IFindRoleByName` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Modules.Identity.Services.Roles.IListRoles](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-ilistroles/index.md) - Lists roles through the standard paged feature contract. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.IUpdateRole](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-iupdaterole/index.md) - Updates the role identified by a `Guid`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.RoleDto](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-roledto/index.md) - Transfers a role identifier and display name without exposing a provider entity. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.RoleSearchModel](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-rolesearchmodel/index.md) - Describes paging, name filtering, and ordering requested when roles are listed. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Roles.UpdateRoleRequest](kamisama-modules-identity-services-roles/kamisama-modules-identity-services-roles-updaterolerequest/index.md) - Contains the replacement name for an existing role. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.AddUserRequest](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-adduserrequest/index.md) - Contains identity, credential, activation, and role values requested when a user is created. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.Enable2faRequest](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-enable2farequest/index.md) - Supplies a user and verification code when enabling two-factor authentication. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IAddUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-iadduser/index.md) - Creates a user through the standard add-feature contract. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IDeleteUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ideleteuser/index.md) - Deletes the user identified by a `Guid`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IDisable2fa](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-idisable2fa/index.md) - Disables two-factor authentication for a user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IDisableUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-idisableuser/index.md) - Disables a user&apos;s ability to authenticate according to implementation-defined lockout semantics. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IEnable2fa](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ienable2fa/index.md) - Enables two-factor authentication after validating an authenticator code. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IEnableUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ienableuser/index.md) - Enables a user according to implementation-defined lockout semantics. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IExistsUserByEmail](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-iexistsuserbyemail/index.md) - Checks whether a user exists for an email address. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IExistsUserById](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-iexistsuserbyid/index.md) - Checks whether a user exists for a `Guid` identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IExistsUserByName](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-iexistsuserbyname/index.md) - Checks whether a user exists for a user name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IFindCurrentUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ifindcurrentuser/index.md) - Resolves the user represented by the current execution context. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IFindUserByEmail](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ifinduserbyemail/index.md) - Finds a user by email address. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IFindUserById](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ifinduserbyid/index.md) - Finds a user by a `Guid` identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IFindUserByName](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ifinduserbyname/index.md) - Finds a user by user name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IListUsers](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-ilistusers/index.md) - Lists users through the standard paged feature contract. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.IUpdateUser](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-iupdateuser/index.md) - Updates the user identified by a `Guid`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.UpdateUserRequest](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-updateuserrequest/index.md) - Contains replacement profile and role values requested for an existing user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.UserDto](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-userdto/index.md) - Transfers a user&apos;s identity, role names, and effective enabled state without exposing a provider entity. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.Identity.Services.Users.UserSearchModel](kamisama-modules-identity-services-users/kamisama-modules-identity-services-users-usersearchmodel/index.md) - Describes paging, identity text, role, and ordering criteria requested when users are listed. Use it with the surrounding package APIs when composing application code.
