# ISetTwoFactorAuthenticationEnabled

<a id="isettwofactorauthenticationenabled"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L65)

Namespace: `KamiSama.Modules.Identity.Services.AccountSecurity`

Kind: `Interface`

## Description

Enables or disables two-factor authentication for a user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ISetTwoFactorAuthenticationEnabled
```

## Example

```csharp
await setTwoFactorAuthenticationEnabled.SetAsync(userId, true, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SetAsync](method-setasync-72.md) | Sets the user&apos;s two-factor enabled flag. Use it with the surrounding package APIs when composing application code. |

