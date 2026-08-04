# AutoXmlElement<TValue>

<a id="autoxmlelement-tvalue"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlElement.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElement.cs#L8)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

This class wraps an element in order to always have the same name outside while inside is different. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class AutoXmlElement<TValue> : IEquatable<AutoXmlElement<TValue>>, IEquatable<TValue>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Equals](method-equals-33.md) | Runs the `Equals` operation on `AutoXmlElement<TValue>`. Use it when your code needs this specific behavior from the package. |
| [GetHashCode](method-gethashcode-43.md) | Runs the `GetHashCode` operation on `AutoXmlElement<TValue>`. Use it when your code needs this specific behavior from the package. |

### Operators

| Member | Description |
| --- | --- |
| [operator AutoXmlElement<TValue>](operator-operator-autoxmlelement-tvalue-19.md) | implicit operator to convert &lt;typeparamref name=&quot;TValue&quot;/&gt; to `AutoXmlElement{TElement}`. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Value](property-value-13.md) | Exposes the `Value` value on `AutoXmlElement<TValue>`. Read or set it as part of configuring or using the type. |

