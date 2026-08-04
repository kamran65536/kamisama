# Equals

[Back to AutoXmlElement<TValue>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElement.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElement.cs#L33)

Type: `KamiSama.Extensions.AutoXmlElement<TValue>`

Kind: `Method`

## Description

Runs the `Equals` operation on `AutoXmlElement<TValue>`. Use it when your code needs this specific behavior from the package.

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

