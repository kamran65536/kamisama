# SetAsync

[Back to ISetTwoFactorAuthenticationEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:72](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L72)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.ISetTwoFactorAuthenticationEnabled`

Kind: `Method`

## Description

Sets the user&apos;s two-factor enabled flag. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task SetAsync(Guid userId, bool isEnabled, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The target user identifier. |
| `isEnabled` | `bool` | `-` | The requested enabled state. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the update. |

## Example

```csharp
await setTwoFactorAuthenticationEnabled.SetAsync(userId, true, cancellationToken);
```

