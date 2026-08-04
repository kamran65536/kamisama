# IDisableUser

<a id="idisableuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L18)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Interface`

## Description

Defines the contract for `IDisableUser` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface IDisableUser
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DisableUserAsync](method-disableuserasync-20.md) | Runs the `DisableUserAsync` operation on `IDisableUser`. Use it when your code needs this specific behavior from the package. |

