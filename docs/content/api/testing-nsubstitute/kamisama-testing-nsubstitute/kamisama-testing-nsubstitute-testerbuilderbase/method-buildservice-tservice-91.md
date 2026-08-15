# BuildService<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:91](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L91)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Selects the first public constructor reported by reflection, probes its parameters through a temporary provider, and registers scoped substitutes for unresolved parameter types before building the target in a new scope. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService BuildService<TService>()
    where TService : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TService` | The concrete service type to register and resolve. |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `TService` | The scoped target service resolved from the newly created final scope. |

## Remarks

Only the selected constructor&apos;s unresolved dependencies are substituted, and NSubstitute can only proxy supported interfaces or classes with overridable members. Temporary providers and scopes, the final provider, and any previously assigned `ServiceScope` are not disposed by this type.

## Example

```csharp
ProductService service = builder.BuildService<ProductService>();
```

