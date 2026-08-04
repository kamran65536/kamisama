# ValidateAsync

[Back to IApplicationSessionManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IApplicationSessionManager.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/IApplicationSessionManager.cs#L8)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.IApplicationSessionManager`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `IApplicationSessionManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<ApplicationSession> ValidateAsync(ClaimsPrincipal principal, CancellationToken cancellationToken);
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

