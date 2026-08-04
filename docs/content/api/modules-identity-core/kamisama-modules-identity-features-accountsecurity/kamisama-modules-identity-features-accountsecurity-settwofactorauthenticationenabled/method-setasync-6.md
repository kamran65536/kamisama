# SetAsync

[Back to SetTwoFactorAuthenticationEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/SetTwoFactorAuthenticationEnabled.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/SetTwoFactorAuthenticationEnabled.cs#L6)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.SetTwoFactorAuthenticationEnabled`

Kind: `Method`

## Description

Runs the `SetAsync` operation on `SetTwoFactorAuthenticationEnabled`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task SetAsync(Guid userId, bool isEnabled, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `isEnabled` | `bool` | `-` | The `isEnabled` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

