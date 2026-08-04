# ISetTwoFactorAuthenticationEnabled

<a id="isettwofactorauthenticationenabled"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L33)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Interface`

## Description

Defines the contract for `ISetTwoFactorAuthenticationEnabled` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface ISetTwoFactorAuthenticationEnabled
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SetAsync](method-setasync-35.md) | Runs the `SetAsync` operation on `ISetTwoFactorAuthenticationEnabled`. Use it when your code needs this specific behavior from the package. |

