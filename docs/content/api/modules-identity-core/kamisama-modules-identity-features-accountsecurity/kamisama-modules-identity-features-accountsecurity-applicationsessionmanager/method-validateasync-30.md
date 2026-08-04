# ValidateAsync

[Back to ApplicationSessionManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionManager.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionManager.cs#L30)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ApplicationSessionManager`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `ApplicationSessionManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<ApplicationSession> ValidateAsync(ClaimsPrincipal principal, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `principal` | `ClaimsPrincipal` | `-` | The `principal` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationSession>` | Returns a `Task<ApplicationSession>` value. |

## Example

No concise standalone example is available yet.

