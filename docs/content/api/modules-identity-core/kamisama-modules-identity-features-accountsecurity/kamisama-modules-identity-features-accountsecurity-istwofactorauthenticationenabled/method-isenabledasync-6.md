# IsEnabledAsync

[Back to IsTwoFactorAuthenticationEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IsTwoFactorAuthenticationEnabled.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IsTwoFactorAuthenticationEnabled.cs#L6)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.IsTwoFactorAuthenticationEnabled`

Kind: `Method`

## Description

Runs the `IsEnabledAsync` operation on `IsTwoFactorAuthenticationEnabled`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

