# ListAsync

[Back to IListAvailableCultures](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L5)

Type: `KamiSama.Modules.Localization.Features.IListAvailableCultures`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `IListAvailableCultures`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto[]>` | Returns a `Task<CultureInfoDto[]>` value. |

## Example

No concise standalone example is available yet.

