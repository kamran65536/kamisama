# IListAvailableCultures

<a id="ilistavailablecultures"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L6)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Interface`

## Description

Defines provider-neutral culture discovery. Implementations decide storage, cancellation, and whether returned arrays are mutable or copied.

## Declaration

```csharp
public interface IListAvailableCultures
```

## Example

```csharp
CultureInfoDto[] cultures = await listAvailableCultures.ListAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-13.md) | Returns the cultures exposed by the implementation. Use it with the surrounding package APIs when composing application code. |

