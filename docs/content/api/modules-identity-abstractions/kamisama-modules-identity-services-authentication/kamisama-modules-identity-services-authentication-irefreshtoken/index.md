# IRefreshToken

<a id="irefreshtoken"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Authentication/Features.cs#L14)

Namespace: `KamiSama.Modules.Identity.Services.Authentication`

Kind: `Interface`

## Description

Defines replacement-token issuance for the session represented by an access/refresh-token pair. Core validates access-token signature and claims, active session state, and the session-scoped refresh token before returning replacements.

## Declaration

```csharp
public interface IRefreshToken
```

## Example

```csharp
TokenPairDto tokens = await refreshToken.RefreshAsync(
    new RefreshTokenRequest(accessToken, refreshTokenValue),
    cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [RefreshAsync](method-refreshasync-20.md) | Refreshes the supplied token pair without creating a second application session. Use it with the surrounding package APIs when composing application code. |

