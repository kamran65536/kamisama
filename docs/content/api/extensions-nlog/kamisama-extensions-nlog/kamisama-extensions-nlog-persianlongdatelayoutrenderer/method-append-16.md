# Append

[Back to PersianLongDateLayoutRenderer](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md)

Source: [src/NLog/PersianLongDateLayoutRenderer.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianLongDateLayoutRenderer.cs#L16)

Type: `KamiSama.Extensions.NLog.PersianLongDateLayoutRenderer`

Kind: `Method`

## Description

Appends the event timestamp in the fixed Persian-calendar long-date format. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected override void Append(StringBuilder builder, LogEventInfo logEvent);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder` | `StringBuilder` | `-` | The buffer that receives the rendered timestamp. |
| `logEvent` | `LogEventInfo` | `-` | The NLog event whose timestamp is rendered. |

## Example

No concise standalone example is available yet.

