# LogoutAsync

[Back to ILogout](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L29)

Type: `KamiSama.Modules.Identity.Services.Authentication.ILogout`

Kind: `Method`

## Description

Revokes the current session so its cookie or access and refresh tokens can no longer authenticate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task LogoutAsync(CancellationToken cancellationToken);
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
// Core resolves the user and session from the current authenticated HTTP context.
await logout.LogoutAsync(cancellationToken);
```

