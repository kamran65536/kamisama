# IValidatePassword

<a id="ivalidatepassword"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Features.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Password`

Kind: `Interface`

## Description

Defines the contract for `IValidatePassword` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IValidatePassword
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ValidateAsync](method-validateasync-5.md) | Runs the `ValidateAsync` operation on `IValidatePassword`. Use it when your code needs this specific behavior from the package. |

