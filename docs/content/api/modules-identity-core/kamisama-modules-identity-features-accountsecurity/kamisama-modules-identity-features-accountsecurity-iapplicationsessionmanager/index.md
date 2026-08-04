# IApplicationSessionManager

<a id="iapplicationsessionmanager"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IApplicationSessionManager.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IApplicationSessionManager.cs#L5)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Interface`

## Description

Defines the contract for `IApplicationSessionManager` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
internal interface IApplicationSessionManager
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [CreateAsync](method-createasync-7.md) | Runs the `CreateAsync` operation on `IApplicationSessionManager`. Use it when your code needs this specific behavior from the package. |
| [ValidateAsync](method-validateasync-8.md) | Runs the `ValidateAsync` operation on `IApplicationSessionManager`. Use it when your code needs this specific behavior from the package. |

