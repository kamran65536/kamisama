# IValidateAuthenticatorCodeIfEnabled

<a id="ivalidateauthenticatorcodeifenabled"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Interface`

## Description

Defines the contract for `IValidateAuthenticatorCodeIfEnabled` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
internal interface IValidateAuthenticatorCodeIfEnabled
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-5.md) | Runs the `ValidateAsync` operation on `IValidateAuthenticatorCodeIfEnabled`. Use it when your code needs this specific behavior from the package. |

