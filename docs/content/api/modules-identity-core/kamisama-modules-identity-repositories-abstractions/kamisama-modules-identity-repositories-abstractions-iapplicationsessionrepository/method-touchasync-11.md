# TouchAsync

[Back to IApplicationSessionRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs#L11)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationSessionRepository`

Kind: `Method`

## Description

Runs the `TouchAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task TouchAsync(ApplicationSession session, DateTime utcNow, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `session` | `ApplicationSession` | `-` | The `session` value passed to this member. |
| `utcNow` | `DateTime` | `-` | The `utcNow` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

