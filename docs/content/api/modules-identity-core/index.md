# KamiSama.Modules.Identity.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core Identity implementation for KamiSama login, token refresh, logout, user, role, password, two-factor, and session feature contracts, with revocable JWT sessions, EF Core persistence, mappings, and modular startup registration. Install it with exactly one Identity database provider and review the documented security and runtime limitations before exposing its features.

## How to use

```shell
dotnet add package KamiSama.Modules.Identity.Core --version 10.0.0
```

**Publication mismatch:** version `10.0.0` in the install command is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the root-version command in repository documentation; use an actually published version when installing from NuGet.

Install exactly one provider package, pass its callback, and add authentication before authorization in the application pipeline:

```csharp
using KamiSama.Modules;
using KamiSama.Modules.Identity;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddKamiSamaIdentityModule(
        webBuilder.Configuration.GetSection("Identity"),
        webBuilder.Configuration.GetSection("Identity:Database"),
        registerIdentity: true,
        useJwtAuth: true,
        configureDbContext: database => database.AddPostgresqlIdentityDbContext());

var app = await builder.BuildAsync(CancellationToken.None);
app.UseAuthentication();
app.UseAuthorization();
```

The provider callback is nullable in the signature but mandatory in practice unless another registration adds the keyed concrete context. `BuildAsync` runs configured migration and seed work before returning the application, so startup needs database access and can fail or block while migration runs. The module configures authentication services but does not call `UseAuthentication`; place it before `UseAuthorization` and protected endpoints.

`registerIdentity: true, useJwtAuth: true` is the self-contained JWT configuration. `true, false` uses Identity application/external scheme defaults and requires the host's intended cookie setup. `false, true` configures JWT only but Core features still require externally registered Identity managers, stores, and token providers. `false, false` configures Identity scheme names without registering their handlers or Core dependencies, so it is usable only when the host supplies the complete Identity setup.

**Security limitations:** feature interfaces and implementations do not authorize the caller or verify that caller-controlled user IDs, role IDs, or session IDs may be operated on. Find/exists/reset behavior can disclose whether an account exists. `ResetPasswordAsync` looks up a user and generates its own reset token before applying the caller-supplied password; exposing it directly permits password reset without possession of an out-of-band token. `ChangePassword` authenticates without supplying a two-factor code, so password change fails for users whose two-factor authentication is enabled. Add endpoint authorization, ownership checks, uniform public responses, and a separate issued-token reset flow before exposing these services.

**Runtime and data limitations:** `UpdateUserRequest.Roles`, `UserSearchModel.RoleName`, and `UserSearchModel.OrderBy` are ignored. User-name/email search applies a second exact user-name predicate, so email-only and partial searches can unexpectedly return no rows. User creation can persist the user before confirmation or role assignment fails, and update/role/session workflows do not provide a cross-operation transaction or rollback. Many UserManager calls and feature paths do not propagate cancellation.

JWT bearer metadata validation is disabled, login does not reject disabled users, and the `isEnabled` claim is based on email confirmation rather than the DTO lockout calculation. Login resolves a matching user name before trying the same value as an email address, then creates a persistent session and returns its absolute access-token expiration. Logout operations require name-identifier and session claims from the active HTTP context; revocation invalidates later session validation but does not remove a cookie or bearer token from the client. Session validation touches and saves the session on authenticated traffic, refresh issuance performs repeated user/token lookups, and repositories save mutations immediately. User listing performs one role lookup per returned user and its unused `ConvertToDto` hook throws `NotImplementedException`, making the implementation dependent on its custom page-conversion path. Account for this database write/query amplification and do not call that conversion hook independently.

## Namespaces

- [KamiSama.Modules.Identity](kamisama-modules-identity/index.md) (3 types)
- [KamiSama.Modules.Identity.Entities](kamisama-modules-identity-entities/index.md) (3 types)
- [KamiSama.Modules.Identity.Repositories.Abstractions](kamisama-modules-identity-repositories-abstractions/index.md) (2 types)
- [KamiSama.Modules.Identity.Repositories.Database](kamisama-modules-identity-repositories-database/index.md) (1 types)

## Types

- [KamiSama.Modules.Identity.DtoMappings](kamisama-modules-identity/kamisama-modules-identity-dtomappings/index.md) - Maps Identity users and roles to abstraction DTOs. User mapping requires roles to be loaded separately and calculates enabled state from lockout fields.
- [KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions](kamisama-modules-identity/kamisama-modules-identity-extendedwebapplicationbuilderextensions/index.md) - Adds the Identity Core web module to an extended builder. Its provider callback must register one installed Identity database provider before startup context resolution.
- [KamiSama.Modules.Identity.KamiSamaIdentityWebModule](kamisama-modules-identity/kamisama-modules-identity-kamisamaidentitywebmodule/index.md) - Registers Identity, authentication, scanned feature implementations, and a multi-provider DbContext, then performs configured database initialization after build. A concrete provider callback and correctly ordered authentication middleware are required in practice.
- [KamiSama.Modules.Identity.Entities.ApplicationRole](kamisama-modules-identity-entities/kamisama-modules-identity-entities-applicationrole/index.md) - ASP.NET Core Identity role with a `Guid` key. Use it with the Core Identity store and role feature implementations.
- [KamiSama.Modules.Identity.Entities.ApplicationSession](kamisama-modules-identity-entities/kamisama-modules-identity-entities-applicationsession/index.md) - Persistent revocable authentication session. Validation updates and saves `LastConnection`, producing database writes on authenticated traffic.
- [KamiSama.Modules.Identity.Entities.ApplicationUser](kamisama-modules-identity-entities/kamisama-modules-identity-entities-applicationuser/index.md) - ASP.NET Core Identity user with a `Guid` key and application-session navigation. Inherited Identity state stores credentials, confirmation, and lockout data.
- [KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository](kamisama-modules-identity-repositories-abstractions/kamisama-modules-identity-repositories-abstractions-iapplicationrolerepository/index.md) - Combines Core role mutation, paging, and identifier/name lookup contracts. Concrete repository behavior determines normalization and save boundaries.
- [KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationUserRepository](kamisama-modules-identity-repositories-abstractions/kamisama-modules-identity-repositories-abstractions-iapplicationuserrepository/index.md) - Defines Core user persistence, paging, and lookup. The current implementation saves immediately and does not honor every `UserSearchModel` field.
- [KamiSama.Modules.Identity.Repositories.Database.KamiSamaIdentityDbContext](kamisama-modules-identity-repositories-database/kamisama-modules-identity-repositories-database-kamisamaidentitydbcontext/index.md) - Identity EF Core context for users, roles, claims, tokens, and revocable sessions. Core can migrate it during the extended builder's post-build startup phase.
