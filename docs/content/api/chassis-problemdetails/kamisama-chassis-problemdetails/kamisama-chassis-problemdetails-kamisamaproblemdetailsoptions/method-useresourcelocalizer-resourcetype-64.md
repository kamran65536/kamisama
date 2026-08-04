# UseResourceLocalizer<ResourceType>

[Back to KamiSamaProblemDetailsOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.ProblemDetails](../../index.md)

Source: [src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs:64](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L64)

Type: `KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions`

Kind: `Method`

## Description

Uses Resource String Localizer. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
//public KamiSamaProblemDetailsOptions UseResourceLocalizer(string typeName, string assemblyName)
//{
//	this.StringLocalizerFunc = sp => sp.GetRequiredService<IStringLocalizerFactory>().Create(typeName, assemblyName);
//	return this;
//}
public KamiSamaProblemDetailsOptions UseResourceLocalizer<ResourceType>();
```

## Type Parameters

| Name | Description |
| --- | --- |
| `ResourceType` |  |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `KamiSamaProblemDetailsOptions` | Returns a `KamiSamaProblemDetailsOptions` value. |

## Example

No concise standalone example is available yet.

