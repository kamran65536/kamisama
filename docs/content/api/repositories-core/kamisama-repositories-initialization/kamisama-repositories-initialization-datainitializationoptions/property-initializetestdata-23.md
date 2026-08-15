# InitializeTestData

[Back to DataInitializationOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/Initialization/DataInitializationOptions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/DataInitializationOptions.cs#L23)

Type: `KamiSama.Repositories.Initialization.DataInitializationOptions`

Kind: `Property`

## Description

Gets or sets whether the initializer should create test data; production callers normally leave this disabled.

## Declaration

```csharp
public bool InitializeTestData { get; set; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `bool` value. |

## Example

```csharp
var options = new DataInitializationOptions
{
    Migrate = true,
    InitializeData = true,
    InitializeTestData = false
};
```

