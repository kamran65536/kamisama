# IIsTwoFactorAuthenticationEnabled

<a id="iistwofactorauthenticationenabled"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:55](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L55)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Checks whether two-factor authentication is enabled for a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IIsTwoFactorAuthenticationEnabled
```

## Example

```csharp
bool enabled = await twoFactorStatus.IsEnabledAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [IsEnabledAsync](method-isenabledasync-61.md) | Returns whether two-factor authentication is enabled. Use it with the surrounding package APIs when composing application code. |

