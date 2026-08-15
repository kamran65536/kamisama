# IGetCurrentCulture

<a id="igetcurrentculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Abstractions/Features/Features.cs#L18)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Interface`

## Description

Defines provider-neutral current-culture lookup. Implementations decide the execution context, matching, fallback, and cancellation behavior.

## Declaration

```csharp
public interface IGetCurrentCulture
```

## Example

```csharp
CultureInfoDto current = await getCurrentCulture.GetCurrentCultureAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentCultureAsync](method-getcurrentcultureasync-25.md) | Returns metadata for the current UI culture according to the implementation&apos;s matching and fallback rules. Use it with the surrounding package APIs when composing application code. |

