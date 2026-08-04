# RefreshAsync

[Back to IRefreshAccessToken](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:46](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L46)

Type: `KamiSama.Modules.Identity.Features.Users.IRefreshAccessToken`

Kind: `Method`

## Description

Runs the `RefreshAsync` operation on `IRefreshAccessToken`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<RefreshAccessTokenResponse> RefreshAsync(RefreshAccessTokenRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `RefreshAccessTokenRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<RefreshAccessTokenResponse>` | Returns a `Task<RefreshAccessTokenResponse>` value. |

## Example

No concise standalone example is available yet.

