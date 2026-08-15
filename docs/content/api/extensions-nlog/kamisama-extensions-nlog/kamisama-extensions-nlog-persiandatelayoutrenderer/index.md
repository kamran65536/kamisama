# PersianDateLayoutRenderer

<a id="persiandatelayoutrenderer"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md) | [Back to package index](../../../index.md)

Source: [src/NLog/PersianDateLayoutRenderer.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianDateLayoutRenderer.cs#L7)

Namespace: `KamiSama.Extensions.NLog`

Kind: `Class`

## Description

Renders an NLog event timestamp with a configurable Persian-calendar date and time format. Use `Format` to select the output accepted by the Persian date formatting extensions.

## Declaration

```csharp
public class PersianDateLayoutRenderer : LayoutRenderer
```

## Example

```csharp
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianDateLayoutRenderer>("persian-date");
var layout = NLog.Layouts.Layout.FromString("${persian-date:format=yyyy/MM/dd}");
```

## Constructors

### PersianDateLayoutRenderer

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianDateLayoutRenderer.cs#L19)

Initializes a renderer that uses the default `yyyy/MM/dd HH:mm:ss.fff` format. Use it with the surrounding package APIs when composing application code.

```csharp
public PersianDateLayoutRenderer();
```

## Parameters

This member does not declare parameters.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Append](method-append-28.md) | Converts the event timestamp to the configured Persian-calendar format and appends it to the layout output. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Format](property-format-14.md) | Gets or sets the Persian date and time format used to render the event timestamp. The default format is `yyyy/MM/dd HH:mm:ss.fff`. |

