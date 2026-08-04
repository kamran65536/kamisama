# RefreshAccessToken

<a id="refreshaccesstoken"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/RefreshAccessToken.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/RefreshAccessToken.cs#L10)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Class`

## Description

Provides the `RefreshAccessToken` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class RefreshAccessToken(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	ITokenService tokenService,
	IOptions<JwtOptions> options) : IRefreshAccessToken
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/RefreshAccessToken.cs#L10)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class RefreshAccessToken(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	ITokenService tokenService,
	IOptions<JwtOptions> options) : IRefreshAccessToken
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userManager` | `IUserManager` | `-` | The `userManager` value passed to this member. |
| `sessionManager` | `IApplicationSessionManager` | `-` | The `sessionManager` value passed to this member. |
| `tokenService` | `ITokenService` | `-` | The `tokenService` value passed to this member. |
| `options` | `IOptions<JwtOptions>` | `-` | The `options` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [RefreshAsync](method-refreshasync-17.md) | Runs the `RefreshAsync` operation on `RefreshAccessToken`. Use it when your code needs this specific behavior from the package. |

