# IsEnabledAsync

[Back to IIsTwoFactorAuthenticationEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L30)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.IIsTwoFactorAuthenticationEnabled`

Kind: `Method`

## Description

Runs the `IsEnabledAsync` operation on `IIsTwoFactorAuthenticationEnabled`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken);
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

