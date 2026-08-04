# GetAuthenticatorSecret

<a id="getauthenticatorsecret"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/GetAuthenticatorSecret.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/GetAuthenticatorSecret.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `GetAuthenticatorSecret` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class GetAuthenticatorSecret(IUserManager userManager) : IGetAuthenticatorSecret
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/GetAuthenticatorSecret.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class GetAuthenticatorSecret(IUserManager userManager) : IGetAuthenticatorSecret
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetAsync](method-getasync-6.md) | Runs the `GetAsync` operation on `GetAuthenticatorSecret`. Use it when your code needs this specific behavior from the package. |

