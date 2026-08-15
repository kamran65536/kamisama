# PersianLongDateLayoutRenderer

<a id="persianlongdatelayoutrenderer"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md) | [Back to package index](../../../index.md)

Source: [src/NLog/PersianLongDateLayoutRenderer.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianLongDateLayoutRenderer.cs#L7)

Namespace: `KamiSama.Extensions.NLog`

Kind: `Class`

## Description

Renders an NLog event timestamp as a Persian-calendar date with time and four fractional-second digits. The fixed output format is `yyyy-MM-dd HH:mm:ss.ffff`.

## Declaration

```csharp
public class PersianLongDateLayoutRenderer : LayoutRenderer
```

## Example

```csharp
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianLongDateLayoutRenderer>("persian-longDate");
var layout = NLog.Layouts.Layout.FromString("${persian-longDate}");
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Append](method-append-16.md) | Appends the event timestamp in the fixed Persian-calendar long-date format. Use it with the surrounding package APIs when composing application code. |

