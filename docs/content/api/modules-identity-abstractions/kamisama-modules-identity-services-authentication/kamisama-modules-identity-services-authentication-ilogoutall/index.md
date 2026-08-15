# ILogoutAll

<a id="ilogoutall"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L33)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Interface`

## Description

Defines revocation of every application session for the current authenticated user, including the caller's session. Core resolves the user claim from the active HTTP context and persists revocation for all active sessions.

## Declaration

```csharp
public interface ILogoutAll
```

## Example

```csharp
// Revokes the current session and every other active session for the current user.
await logoutAll.LogoutAllAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [LogoutAllAsync](method-logoutallasync-38.md) | Revokes all sessions, including the session making the request. Use it with the surrounding package APIs when composing application code. |

