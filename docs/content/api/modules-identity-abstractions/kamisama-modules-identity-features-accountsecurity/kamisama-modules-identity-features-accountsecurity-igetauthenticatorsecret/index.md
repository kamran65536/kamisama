# IGetAuthenticatorSecret

<a id="igetauthenticatorsecret"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L18)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Interface`

## Description

Defines the contract for `IGetAuthenticatorSecret` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IGetAuthenticatorSecret
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetAsync](method-getasync-20.md) | Runs the `GetAsync` operation on `IGetAuthenticatorSecret`. Use it when your code needs this specific behavior from the package. |

