# GenerateRefreshTokenAsync

[Back to TokenService](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/TokenService.cs:59](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/TokenService.cs#L59)

Type: `KamiSama.Modules.Identity.Features.Users.TokenService`

Kind: `Method`

## Description

Runs the `GenerateRefreshTokenAsync` operation on `TokenService`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<string> GenerateRefreshTokenAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `sessionKey` | `string` | `-` | The `sessionKey` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<string>` | Returns a `Task<string>` value. |

## Example

No concise standalone example is available yet.

