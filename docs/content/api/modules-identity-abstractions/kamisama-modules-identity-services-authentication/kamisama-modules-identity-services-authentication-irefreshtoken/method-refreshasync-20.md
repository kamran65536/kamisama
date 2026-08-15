# RefreshAsync

[Back to IRefreshToken](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L20)

Type: `KamiSama.Modules.Identity.Services.Authentication.IRefreshToken`

Kind: `Method`

## Description

Refreshes the supplied token pair without creating a second application session. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TokenPairDto> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `RefreshTokenRequest` | `-` | The access and refresh tokens to validate. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TokenPairDto>` | The replacement token pair and its access-token expiration. |

## Example

```csharp
TokenPairDto tokens = await refreshToken.RefreshAsync(
    new RefreshTokenRequest(accessToken, refreshTokenValue),
    cancellationToken);
```

