# ServiceCollectionExtension

<a id="servicecollectionextension"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.ProblemDetails/ServiceCollectionExtension.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ServiceCollectionExtension.cs#L11)

Namespace: `KamiSama.Chassis.ProblemDetails`

Kind: `Class`

## Description

Registers the KamiSama ProblemDetails provider and global MVC exception filter. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static class ServiceCollectionExtension
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddExceptionFilterForProblemDetails](method-addexceptionfilterforproblemdetails-21.md) | Adds the scoped conversion services and configures MVC to resolve the exception filter globally. Use it with the surrounding package APIs when composing application code. |

