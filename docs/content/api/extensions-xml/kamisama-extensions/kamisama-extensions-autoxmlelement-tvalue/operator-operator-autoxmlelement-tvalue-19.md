# operator AutoXmlElement<TValue>

[Back to AutoXmlElement<TValue>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElement.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElement.cs#L19)

Type: `KamiSama.Extensions.AutoXmlElement<TValue>`

Kind: `Operator`

## Description

implicit operator to convert &lt;typeparamref name=&quot;TValue&quot;/&gt; to `AutoXmlElement{TElement}`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static implicit operator AutoXmlElement<TValue>(TValue value);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `value` | `TValue` | `-` | The `value` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `AutoXmlElement<TValue>` | Returns a `AutoXmlElement<TValue>` value. |

## Example

No concise standalone example is available yet.

