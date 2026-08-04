# RefreshAsync

[Back to RefreshAccessToken](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/RefreshAccessToken.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/RefreshAccessToken.cs#L17)

Type: `KamiSama.Modules.Identity.Features.Users.RefreshAccessToken`

Kind: `Method`

## Description

Runs the `RefreshAsync` operation on `RefreshAccessToken`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<RefreshAccessTokenResponse> RefreshAsync(RefreshAccessTokenRequest request, CancellationToken cancellationToken);
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

