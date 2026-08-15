# Equals

[Back to AutoXmlElement<TValue>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElement.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElement.cs#L36)

Type: `KamiSama.Extensions.AutoXmlElement<TValue>`

Kind: `Method`

## Description

Determines whether the supplied object is a wrapper with an equal value or a &lt;typeparamref name=&quot;TValue&quot;/&gt; equal to the wrapped value. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override bool Equals(object? obj);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `obj` | `object?` | `-` | The `obj` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `bool` | Returns a `bool` value. |

## Example

```csharp
var element = new AutoXmlElement<object>();
```

