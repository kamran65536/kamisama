namespace KamiSama.Extensions.Json;

/// <summary>
/// Marks the property used by <see cref="HierarchicalJsonConverter{T}"/> as the polymorphic type discriminator.
/// Apply it to exactly one public property on the base type.
/// </summary>
public class JsonHirerarchyDiscriminatorAttribute : JsonAttribute
{
}
