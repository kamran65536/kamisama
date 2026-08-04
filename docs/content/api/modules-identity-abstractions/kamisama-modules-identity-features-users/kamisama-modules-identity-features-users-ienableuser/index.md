# IEnableUser

<a id="ienableuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L22)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Interface`

## Description

Defines the contract for `IEnableUser` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IEnableUser
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [EnableUserAsync](method-enableuserasync-24.md) | Runs the `EnableUserAsync` operation on `IEnableUser`. Use it when your code needs this specific behavior from the package. |

