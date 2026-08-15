# UpdatePolicyListRequest

<a id="updatepolicylistrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs:74](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L74)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Record`

## Description

Supplies replacement values for an existing policy-list definition; existing items are not included. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdatePolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L74)

Supplies replacement values for an existing policy-list definition; existing items are not included. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdatePolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement name, which Core checks against other list names. |
| `Type` | `PolicyListType` | `-` | The replacement declared list type; Core does not convert existing items. |
| `IsEnabled` | `bool` | `-` | Whether the updated definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

