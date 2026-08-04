# IResolveAuthenticationUser

<a id="iresolveauthenticationuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ResolveAuthenticationUser.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ResolveAuthenticationUser.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Interface`

## Description

Defines the contract for `IResolveAuthenticationUser` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
internal interface IResolveAuthenticationUser
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ResolveAsync](method-resolveasync-5.md) | Runs the `ResolveAsync` operation on `IResolveAuthenticationUser`. Use it when your code needs this specific behavior from the package. |

