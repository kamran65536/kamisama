# ChangeAsync

[Back to IChangePassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L25)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.IChangePassword`

Kind: `Method`

## Description

Runs the `ChangeAsync` operation on `IChangePassword`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `ChangePasswordRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

