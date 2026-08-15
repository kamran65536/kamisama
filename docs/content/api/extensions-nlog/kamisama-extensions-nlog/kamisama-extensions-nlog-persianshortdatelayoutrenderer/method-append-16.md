# Append

[Back to PersianShortDateLayoutRenderer](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md)

Source: [src/NLog/PersianShortDateLayoutRenderer.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianShortDateLayoutRenderer.cs#L16)

Type: `KamiSama.Extensions.NLog.PersianShortDateLayoutRenderer`

Kind: `Method`

## Description

Appends the event timestamp in the fixed Persian-calendar short-date format. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected override void Append(StringBuilder builder, LogEventInfo logEvent);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder` | `StringBuilder` | `-` | The buffer that receives the rendered date. |
| `logEvent` | `LogEventInfo` | `-` | The NLog event whose timestamp is rendered. |

## Example

No concise standalone example is available yet.

