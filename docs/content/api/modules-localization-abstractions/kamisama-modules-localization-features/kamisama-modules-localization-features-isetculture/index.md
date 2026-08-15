# ISetCulture

<a id="isetculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L31)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Interface`

## Description

Defines provider-neutral culture selection. Implementations decide validation, persistence, request effects, and cancellation behavior.

## Declaration

```csharp
public interface ISetCulture
```

## Example

```csharp
CultureInfoDto selected = await setCulture.SetAsync("fa-IR", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [SetAsync](method-setasync-39.md) | Selects the requested culture according to the implementation&apos;s validation and persistence behavior. Use it with the surrounding package APIs when composing application code. |

