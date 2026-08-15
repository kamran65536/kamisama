---
last-checked-utc: 2026-08-15T01:03:45Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Identity.Services.AccountSecurity.ActiveSessionDto
  - KamiSama.Modules.Identity.Services.AccountSecurity.ChangePasswordRequest
  - KamiSama.Modules.Identity.Services.AccountSecurity.ValidateAuthenticatorCodeRequest
  - KamiSama.Modules.Identity.Services.Authentication.LoginRequest
  - KamiSama.Modules.Identity.Services.Authentication.LoginResponse
  - KamiSama.Modules.Identity.Services.Authentication.RefreshTokenRequest
  - KamiSama.Modules.Identity.Services.Authentication.TokenPairDto
  - KamiSama.Modules.Identity.Services.Password.PasswordValidationError
  - KamiSama.Modules.Identity.Services.Password.ResetPasswordRequest
  - KamiSama.Modules.Identity.Services.Password.ValidatePasswordRequest
  - KamiSama.Modules.Identity.Services.Roles.AddRoleRequest
  - KamiSama.Modules.Identity.Services.Roles.RoleDto
  - KamiSama.Modules.Identity.Services.Roles.RoleSearchModel
  - KamiSama.Modules.Identity.Services.Roles.UpdateRoleRequest
  - KamiSama.Modules.Identity.Services.Users.AddUserRequest
  - KamiSama.Modules.Identity.Services.Users.Enable2faRequest
  - KamiSama.Modules.Identity.Services.Users.UpdateUserRequest
  - KamiSama.Modules.Identity.Services.Users.UserDto
  - KamiSama.Modules.Identity.Services.Users.UserSearchModel
---

# Documentation Snapshot

The package description, all public contract and data summaries, authentication and feature-interface calling examples, security boundaries, and example exemptions were reviewed against the source at the recorded root version.

## Description

Provider-neutral Identity feature contracts, requests, responses, search models, role constants, and failure metadata for login, token refresh, logout, user, role, password, session, and two-factor workflows.
Reference this package when callers or alternative implementations should not depend on ASP.NET Core Identity, Entity Framework Core, or a database provider.

## How to use

```shell
dotnet add package KamiSama.Modules.Identity.Abstractions --version 10.0.0
```

Inject feature interfaces into application services; Core discovers its implementations when its module is registered. `ILogin` accepts one user name or email value and returns the authenticated user with a new session's tokens, while `IRefreshToken` replaces tokens for an existing session. `ILogout` and `ILogoutAll` use the implementation's current authenticated context. These contracts do not authorize a caller, enforce ownership of user, role, or session IDs, prevent account-enumeration differences, define transaction and cancellation guarantees, or require every search/update field to be honored. Providers must implement those boundaries.

## Example decisions

Every feature interface has an exact-full-name class example showing a DI-resolved call. Authentication examples cover login, token refresh, current-session logout, and all-session logout; token creation is intentionally not exposed as a public abstraction. `KnownRoles` and `AddUserFailedException` have direct examples.

All exact full names listed in `classes-without-examples` are simple request, response, DTO, validation-error, or search records. Their constructor and member documentation fully describes their data shape, so they are exempt from class-level examples.
