# AddOption<TOption>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L27)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Configures an Option in the builder. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void AddOption<TOption>(Action<TOption> configure)
    where TOption : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TOption` | The `TOption` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<TOption>` | `-` | The `configure` value passed to this member. |

## Example

No concise standalone example is available yet.

