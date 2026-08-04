# ITokenService

<a id="itokenservice"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L48)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Interface`

## Description

Defines the contract for `ITokenService` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.

## Declaration

```csharp
public interface ITokenService
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GenerateAccessTokenAsync](method-generateaccesstokenasync-50.md) | Runs the `GenerateAccessTokenAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package. |
| [GenerateAccessTokenAsync](method-generateaccesstokenasync-51.md) | Runs the `GenerateAccessTokenAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package. |
| [GenerateRefreshTokenAsync](method-generaterefreshtokenasync-54.md) | Runs the `GenerateRefreshTokenAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package. |
| [GenerateTokenPairAsync](method-generatetokenpairasync-52.md) | Runs the `GenerateTokenPairAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package. |
| [GenerateTokenPairAsync](method-generatetokenpairasync-53.md) | Runs the `GenerateTokenPairAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package. |

