---
last-checked-utc: 2026-08-15T01:03:45Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, startup and provider requirements, authentication matrix, public type examples, audited security/runtime defects, and example exemptions were reviewed against the source at the recorded root version.

## Description

ASP.NET Core Identity implementation for KamiSama login, token refresh, logout, user, role, password, two-factor, and session feature contracts, with revocable JWT sessions, EF Core persistence, mappings, and modular startup registration.
Install it with exactly one Identity database provider and review the limitations below before exposing its features.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this package version was not published at the time of review. Preserve the root-version command in repository docs and select an actually published version for NuGet installation.

```shell
dotnet add package KamiSama.Modules.Identity.Core --version 10.0.0
```

Pass exactly one installed provider callback to `AddKamiSamaIdentityModule`. Although nullable in the API, the callback is mandatory in practice unless the host separately registers the keyed concrete context. `BuildAsync` runs configured migrations and seed stages before returning the app, so startup needs database connectivity and privileges. The module configures authentication services but not middleware: call `UseAuthentication` before `UseAuthorization` and protected endpoints.

The `registerIdentity`/`useJwtAuth` matrix is: `true/true` for self-contained Core Identity plus JWT; `true/false` for Core Identity with host-completed cookie behavior; `false/true` only when the host supplies all Identity managers, stores, and token providers needed by Core features; `false/false` only when the host supplies both complete Identity dependencies and handlers for the configured Identity schemes.

## Security audit

**Do not expose the feature implementations directly without an authorization layer.** They do not authorize caller access to user, role, or session identifiers. Find, exists, and reset differences can leak account existence. Core `ResetPasswordAsync` generates its own reset token after identity lookup and therefore allows a new password without proof that the caller received an out-of-band token. `ChangePassword` does not pass a two-factor code into authentication, so it fails for users with two-factor authentication enabled.

JWT metadata retrieval is allowed without HTTPS, login does not reject disabled users, and the `isEnabled` claim uses email confirmation rather than the DTO lockout calculation. Logout revokes server-side sessions but does not remove a cookie or bearer token from the client. Add endpoint authorization and ownership checks, uniform account-facing responses, an externally issued reset-token flow, production HTTPS policy, client credential removal, and application-specific disabled-user enforcement.

## Runtime audit

`UpdateUserRequest.Roles`, `UserSearchModel.RoleName`, and `UserSearchModel.OrderBy` are ignored. User search applies an additional exact normalized-user-name predicate after the user-name/email predicate, breaking expected email-only and partial matches. User creation can persist before confirmation or role assignment fails; other multi-step mutation paths likewise provide no cross-operation transaction or rollback. Many UserManager calls ignore or only wrap cancellation.

Login resolves a matching user name before trying the same value as an email address, creates a persistent session, and reports the access token's absolute expiration. Logout requires the relevant identity and session claims in the active HTTP context. Session validation updates and saves `LastConnection` on authenticated traffic. Login and refresh paths repeat user and token lookups, repository mutations save immediately, and user listing performs one role lookup per user. `ListUsers.ConvertToDto` throws `NotImplementedException`; the type works only through its custom page-conversion override and that hook must not be called independently. These paths can cause substantial database write/query amplification.

## Example decisions

`ApplicationUser`, `ApplicationRole`, `ApplicationSession`, `DtoMappings`, `IApplicationUserRepository`, `IApplicationRoleRepository`, `KamiSamaIdentityDbContext`, and `KamiSamaIdentityWebModule` have exact-full-name class examples. Static `ExtendedWebApplicationBuilderExtensions` is exempt because the package How-to, web-module example, and exact `AddKamiSamaIdentityModule` member documentation cover its only operation.
