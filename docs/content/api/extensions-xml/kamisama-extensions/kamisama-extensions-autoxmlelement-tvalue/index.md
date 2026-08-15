# AutoXmlElement<TValue>

<a id="autoxmlelement-tvalue"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlElement.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElement.cs#L9)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Wraps a polymorphic value so its containing XML element can retain a stable name while the nested value uses its concrete type. The implicit conversion makes wrapper creation transparent to callers.

## Declaration

```csharp
public class AutoXmlElement<TValue> : IEquatable<AutoXmlElement<TValue>>, IEquatable<TValue>
```

## Example

```csharp
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

AutoXmlElement<Content> content = new TextContent { Text = "Hello" };
Content wrappedValue = content.Value;
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Equals](method-equals-36.md) | Determines whether the supplied object is a wrapper with an equal value or a &lt;typeparamref name=&quot;TValue&quot;/&gt; equal to the wrapped value. Use it with the surrounding package APIs when composing application code. |
| [GetHashCode](method-gethashcode-48.md) | Returns a hash code derived from the wrapped value. Use it with the surrounding package APIs when composing application code. |

### Operators

| Member | Description |
| --- | --- |
| [operator AutoXmlElement<TValue>](operator-operator-autoxmlelement-tvalue-20.md) | Wraps a &lt;typeparamref name=&quot;TValue&quot;/&gt; instance in an `AutoXmlElement{TValue}`. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Value](property-value-14.md) | Gets or sets the wrapped value serialized inside the stable outer element. Use it with the surrounding package APIs when composing application code. |

