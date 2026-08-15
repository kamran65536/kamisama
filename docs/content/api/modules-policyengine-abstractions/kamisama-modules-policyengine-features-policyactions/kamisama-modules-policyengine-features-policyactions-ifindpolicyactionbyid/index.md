# IFindPolicyActionById

<a id="ifindpolicyactionbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Features.cs#L28)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Interface`

## Description

Defines lookup of one complete action definition by `Guid`. Core returns opaque handler configuration without executing it.

## Declaration

```csharp
public interface IFindPolicyActionById : IFindByIdFeature<PolicyActionDto, Guid>;
```

## Example

```csharp
PolicyActionDto action = await findAction.FindByIdAsync(actionId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

