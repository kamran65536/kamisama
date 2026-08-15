# EnableAsync

[Back to IEnable2fa](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L33)

Type: `KamiSama.Modules.Identity.Services.Users.IEnable2fa`

Kind: `Method`

## Description

Enables two-factor authentication using the supplied setup verification. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task EnableAsync(Enable2faRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `Enable2faRequest` | `-` | The target user and authenticator verification code. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the update. |

## Example

```csharp
await enable2fa.EnableAsync(new Enable2faRequest(userId, authenticatorCode), cancellationToken);
```

