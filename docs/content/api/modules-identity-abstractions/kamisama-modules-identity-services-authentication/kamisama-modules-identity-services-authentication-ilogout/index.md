# ILogout

<a id="ilogout"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L24)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Interface`

## Description

Defines revocation of the current authenticated application session. Core reads user and session claims from the active HTTP context and marks that session revoked in the Identity database.

## Declaration

```csharp
public interface ILogout
```

## Example

```csharp
// Core resolves the user and session from the current authenticated HTTP context.
await logout.LogoutAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [LogoutAsync](method-logoutasync-29.md) | Revokes the current session so its cookie or access and refresh tokens can no longer authenticate. Use it with the surrounding package APIs when composing application code. |

