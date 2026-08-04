# RevokeAsync

[Back to ApplicationSessionRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationSessionRepository.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationSessionRepository.cs#L25)

Type: `KamiSama.Modules.Identity.Repositories.Implementations.ApplicationSessionRepository`

Kind: `Method`

## Description

Runs the `RevokeAsync` operation on `ApplicationSessionRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task RevokeAsync(ApplicationSession session, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `session` | `ApplicationSession` | `-` | The `session` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

