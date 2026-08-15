# PersianShortDateLayoutRenderer

<a id="persianshortdatelayoutrenderer"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md) | [Back to package index](../../../index.md)

Source: [src/NLog/PersianShortDateLayoutRenderer.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianShortDateLayoutRenderer.cs#L7)

Namespace: `KamiSama.Extensions.NLog`

Kind: `Class`

## Description

Renders the date portion of an NLog event timestamp using the Persian calendar. The fixed output format is `yyyy-MM-dd`.

## Declaration

```csharp
public class PersianShortDateLayoutRenderer : LayoutRenderer
```

## Example

```csharp
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianShortDateLayoutRenderer>("persian-shortDate");
var layout = NLog.Layouts.Layout.FromString("${persian-shortDate}");
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Append](method-append-16.md) | Appends the event timestamp in the fixed Persian-calendar short-date format. Use it with the surrounding package APIs when composing application code. |

