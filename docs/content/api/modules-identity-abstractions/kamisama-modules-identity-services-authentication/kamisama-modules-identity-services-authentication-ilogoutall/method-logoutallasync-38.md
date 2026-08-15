# LogoutAllAsync

[Back to ILogoutAll](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L38)

Type: `KamiSama.Modules.Identity.Services.Authentication.ILogoutAll`

Kind: `Method`

## Description

Revokes all sessions, including the session making the request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task LogoutAllAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the revocation operation. |

## Example

```csharp
// Revokes the current session and every other active session for the current user.
await logoutAll.LogoutAllAsync(cancellationToken);
```

