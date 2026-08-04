# TimeSpanJsonConverter

<a id="timespanjsonconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/TimeSpanJsonConverter.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/TimeSpanJsonConverter.cs#L6)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Time Span converter for system.text.json as it sucks displaying timespan values by now! Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-15.md) | parses string as timespan. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-23.md) | Runs the `Write` operation on `TimeSpanJsonConverter`. Use it when your code needs this specific behavior from the package. |

