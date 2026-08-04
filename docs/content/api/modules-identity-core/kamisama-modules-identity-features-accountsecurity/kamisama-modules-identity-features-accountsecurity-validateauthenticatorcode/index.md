# ValidateAuthenticatorCode

<a id="validateauthenticatorcode"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ValidateAuthenticatorCode.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ValidateAuthenticatorCode.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `ValidateAuthenticatorCode` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ValidateAuthenticatorCode(IUserManager userManager) : IValidateAuthenticatorCode
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ValidateAuthenticatorCode.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ValidateAuthenticatorCode(IUserManager userManager) : IValidateAuthenticatorCode
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-6.md) | Runs the `ValidateAsync` operation on `ValidateAuthenticatorCode`. Use it when your code needs this specific behavior from the package. |

