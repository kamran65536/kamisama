# IAddPolicyList

<a id="iaddpolicylist"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Features.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Interface`

## Description

Defines creation of a named typed list definition. The public feature surface provides no operation for adding exact or range items.

## Declaration

```csharp
public interface IAddPolicyList : IAddFeature<AddPolicyListRequest, PolicyListDto>;
```

## Example

```csharp
PolicyListDto list = await addPolicyList.AddAsync(
    new AddPolicyListRequest("Trusted IPs", PolicyListType.IpAddress, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

