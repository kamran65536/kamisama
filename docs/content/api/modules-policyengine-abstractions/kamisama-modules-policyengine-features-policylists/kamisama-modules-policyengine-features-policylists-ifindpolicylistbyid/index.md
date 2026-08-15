# IFindPolicyListById

<a id="ifindpolicylistbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs#L28)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Interface`

## Description

Defines lookup of one list definition by `Guid`. The returned DTO omits exact and range items.

## Declaration

```csharp
public interface IFindPolicyListById : IFindByIdFeature<PolicyListDto, Guid>;
```

## Example

```csharp
PolicyListDto list = await findPolicyList.FindByIdAsync(listId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

