# ListAsync

[Back to IListAvailableCultures](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L13)

Type: `KamiSama.Modules.Localization.Features.IListAvailableCultures`

Kind: `Method`

## Description

Returns the cultures exposed by the implementation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token the implementation may observe while retrieving cultures. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CultureInfoDto[]>` | The available culture metadata. |

## Example

```csharp
CultureInfoDto[] cultures = await listAvailableCultures.ListAsync(cancellationToken);
```

