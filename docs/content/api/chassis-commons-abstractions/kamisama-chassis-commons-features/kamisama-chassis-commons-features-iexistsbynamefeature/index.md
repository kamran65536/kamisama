# IExistsByNameFeature

<a id="iexistsbynamefeature"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByNameFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByNameFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines an existence check for an entity name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IExistsByNameFeature
```

## Example

```csharp
bool exists = await productExists.ExistsByNameAsync("Keyboard", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByNameAsync](method-existsbynameasync-14.md) | Determines whether an entity with the supplied name exists. Use it with the surrounding package APIs when composing application code. |

