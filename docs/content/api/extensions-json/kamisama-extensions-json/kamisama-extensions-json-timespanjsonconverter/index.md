# TimeSpanJsonConverter

<a id="timespanjsonconverter"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/TimeSpanJsonConverter.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/TimeSpanJsonConverter.cs#L7)

Namespace: `KamiSama.Extensions.Json`

Kind: `Class`

## Description

Converts `TimeSpan` values to and from their standard JSON string representation. Use it when an application needs this package&apos;s explicit string-format compatibility behavior.

## Declaration

```csharp
public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
```

## Example

```csharp
using System.Text.Json;
using KamiSama.Extensions;

var options = new JsonSerializerOptions().AddTimeSpanJsonConverter();
string json = JsonSerializer.Serialize(TimeSpan.FromMinutes(5), options);
TimeSpan value = JsonSerializer.Deserialize<TimeSpan>(json, options);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Read](method-read-16.md) | Reads a JSON string token and parses it as a `TimeSpan`. Use it with the surrounding package APIs when composing application code. |
| [Write](method-write-24.md) | Writes the `TimeSpan` as a JSON string using its standard representation. Use it with the surrounding package APIs when composing application code. |

