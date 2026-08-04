# GenerateTokenPairAsync

[Back to TokenService](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/TokenService.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/TokenService.cs#L22)

Type: `KamiSama.Modules.Identity.Features.Users.TokenService`

Kind: `Method`

## Description

Runs the `GenerateTokenPairAsync` operation on `TokenService`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, CancellationToken cancellationToken);
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

