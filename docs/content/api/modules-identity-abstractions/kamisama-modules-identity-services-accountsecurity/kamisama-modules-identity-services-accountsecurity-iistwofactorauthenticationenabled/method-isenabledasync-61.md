# IsEnabledAsync

[Back to IIsTwoFactorAuthenticationEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:61](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L61)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.IIsTwoFactorAuthenticationEnabled`

Kind: `Method`

## Description

Returns whether two-factor authentication is enabled. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The target user identifier. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when enabled; otherwise . |

## Example

```csharp
bool enabled = await twoFactorStatus.IsEnabledAsync(userId, cancellationToken);
```

