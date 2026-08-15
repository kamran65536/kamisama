# Append

[Back to PersianDateLayoutRenderer](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md)

Source: [src/NLog/PersianDateLayoutRenderer.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianDateLayoutRenderer.cs#L28)

Type: `KamiSama.Extensions.NLog.PersianDateLayoutRenderer`

Kind: `Method`

## Description

Converts the event timestamp to the configured Persian-calendar format and appends it to the layout output. Use it with the surrounding package APIs when composing application code.

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

