# IResetPassword

<a id="iresetpassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs#L7)

Namespace: `KamiSama.Modules.Identity.Features.Password`

Kind: `Interface`

## Description

Defines the contract for `IResetPassword` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IResetPassword
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ResetPasswordAsync](method-resetpasswordasync-9.md) | Runs the `ResetPasswordAsync` operation on `IResetPassword`. Use it when your code needs this specific behavior from the package. |

