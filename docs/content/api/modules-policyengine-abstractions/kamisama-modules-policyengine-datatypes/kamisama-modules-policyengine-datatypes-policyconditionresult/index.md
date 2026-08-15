# PolicyConditionResult

<a id="policyconditionresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/DataTypes/PolicyConditionResult.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/DataTypes/PolicyConditionResult.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.DataTypes`

Kind: `Enum`

## Description

Represents false, true, or undefined condition outcomes for a separately implemented evaluator. Undefined is intended for unavailable required facts.

## Declaration

```csharp
public enum PolicyConditionResult
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [False](enum-member-false-11.md) | Indicates that the condition did not match. Use it with the surrounding package APIs when composing application code. |
| [True](enum-member-true-16.md) | Indicates that the condition matched. Use it with the surrounding package APIs when composing application code. |
| [Undefined](enum-member-undefined-21.md) | Indicates that the condition could not be resolved because required facts were unavailable. Use it with the surrounding package APIs when composing application code. |

