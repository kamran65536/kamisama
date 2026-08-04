# SetTwoFactorAuthenticationEnabled

<a id="settwofactorauthenticationenabled"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/SetTwoFactorAuthenticationEnabled.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/SetTwoFactorAuthenticationEnabled.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Class`

## Description

Provides the `SetTwoFactorAuthenticationEnabled` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class SetTwoFactorAuthenticationEnabled(IUserManager userManager) : ISetTwoFactorAuthenticationEnabled
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/SetTwoFactorAuthenticationEnabled.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class SetTwoFactorAuthenticationEnabled(IUserManager userManager) : ISetTwoFactorAuthenticationEnabled
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SetAsync](method-setasync-6.md) | Runs the `SetAsync` operation on `SetTwoFactorAuthenticationEnabled`. Use it when your code needs this specific behavior from the package. |

