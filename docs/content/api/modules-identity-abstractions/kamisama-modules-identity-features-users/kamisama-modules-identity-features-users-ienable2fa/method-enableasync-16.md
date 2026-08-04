# EnableAsync

[Back to IEnable2fa](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L16)

Type: `KamiSama.Modules.Identity.Features.Users.IEnable2fa`

Kind: `Method`

## Description

Runs the `EnableAsync` operation on `IEnable2fa`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task EnableAsync(Enable2faRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `Enable2faRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

