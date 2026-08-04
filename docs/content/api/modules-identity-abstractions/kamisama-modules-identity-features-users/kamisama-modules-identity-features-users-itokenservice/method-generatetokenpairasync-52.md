# GenerateTokenPairAsync

[Back to ITokenService](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:52](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L52)

Type: `KamiSama.Modules.Identity.Features.Users.ITokenService`

Kind: `Method`

## Description

Runs the `GenerateTokenPairAsync` operation on `ITokenService`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TokenPairDto>` | Returns a `Task<TokenPairDto>` value. |

## Example

No concise standalone example is available yet.

